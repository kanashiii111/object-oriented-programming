package config

import (
	"fmt"
	"strings"

	"github.com/spf13/viper"
)

type resource struct {
	Name            string
	Endpoint        string
	Method          string
	Destination_URL string
}

type config struct {
	Server struct {
		Host string
		Port string
	}
	Resources []resource
}

var Config *config

func NewConfig() (*config, error) {
	viper.AddConfigPath("internal/proxy/config/")
	viper.SetConfigName("config")
	viper.SetConfigType("yaml")
	viper.AutomaticEnv()
	viper.SetEnvKeyReplacer(strings.NewReplacer(`.`, `_`))
	err := viper.ReadInConfig()
	if err != nil {
		return nil, fmt.Errorf("error loading config file: %s", err)
	}
	err = viper.Unmarshal(&Config)
	if err != nil {
		return nil, fmt.Errorf("error unmarshalling config: %s", err)
	}
	return Config, nil
}
