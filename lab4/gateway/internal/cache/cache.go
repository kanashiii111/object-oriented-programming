package cache

import (
	"sync"
	"time"
)

type Cache struct {
	data            map[string]interface{}
	expiration      map[string]time.Time
	mutex           sync.RWMutex
	defaultTTL      time.Duration
	cleanupInterval time.Duration
}

func NewCache(defaultTTL, cleanupInterval time.Duration) *Cache {
	cache := &Cache{
		data:            make(map[string]interface{}),
		expiration:      make(map[string]time.Time),
		defaultTTL:      defaultTTL,
		cleanupInterval: cleanupInterval,
	}

	go cache.cleanupExpiredItems()

	return cache
}

func (c *Cache) cleanupExpiredItems() {
	ticker := time.NewTicker(c.cleanupInterval)
	for range ticker.C {
		c.cleanup()
	}
}

func (c *Cache) cleanup() {
	currentTime := time.Now()
	c.mutex.Lock()
	defer c.mutex.Unlock()

	for key, expTime := range c.expiration {
		if currentTime.After(expTime) {
			delete(c.data, key)
			delete(c.expiration, key)
		}
	}
}

func (c *Cache) Set(key string, value interface{}, ttl time.Duration) {
	c.mutex.Lock()
	defer c.mutex.Unlock()

	c.data[key] = value
	c.expiration[key] = time.Now().Add(ttl)
}

func (c *Cache) Get(key string) (interface{}, bool) {
	c.mutex.RLock()
	defer c.mutex.RUnlock()

	value, ok := c.data[key]
	return value, ok
}

func (c *Cache) GetAll() []interface{} {
	c.mutex.RLock()
	defer c.mutex.RUnlock()

	var items []interface{}
	currentTime := time.Now()

	for key, value := range c.data {
		if exp, ok := c.expiration[key]; ok && currentTime.Before(exp) {
			items = append(items, value)
		}
	}
	return items
}
