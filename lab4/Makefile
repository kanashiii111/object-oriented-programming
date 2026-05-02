SHELL := bash.exe

## --- DOCKER ---

build:
	@docker compose up --build -d

env-up:
	@docker compose -f docker-compose.yml --env-file .env up -d

env-down:
	@docker compose -f docker-compose.yml --env-file .env down

env-logs:
	@docker compose -f docker-compose.yml --env-file .env logs -f

migrate-create:
	@if [ -z "$(seq)" ]; then \
		echo "Error: Migration name is required. Usage: make migrate-create seq=<migration_name>"; \
		exit 1; \
	fi; \
	MSYS_NO_PATHCONV=1 docker compose run --rm postgres-migrate \
		create \
		-ext sql \
		-dir /migrations \
		-seq $(seq)

migrate-up:
	@make migrate-action action=up

migrate-down:
	@make migrate-action action=down

migrate-action:
	@if [ -z "$(action)" ]; then \
		echo "Error: Migration action is required. Usage: make migrate-action action=<up|down>"; \
		exit 1; \
	fi; \
	MSYS_NO_PATHCONV=1 docker compose run --rm postgres-migrate \
		-path /migrations \
		-database postgres://${POSTGRES_USER}:${POSTGRES_PASSWORD}@postgres:5432/${POSTGRES_DB}?sslmode=disable \
		$(action)

## --- APP ---

VENV_BIN = ./.venv/Scripts
PYTHON = $(VENV_BIN)/python.exe
GATEWAY_MAIN = C:/Main/Coding/object-oriented-programming/lab4/gateway/cmd/main.go

run-backend:
	$(VENV_BIN)/uvicorn backend.api.main:app --reload --port 5000

run-gateway:
	cd C:/Main/Coding/object-oriented-programming/lab4/gateway && \
	go run $(GATEWAY_MAIN)