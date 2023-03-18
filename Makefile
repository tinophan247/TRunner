clean:
	docker system prune --volumes -f
.PHONY: clean

migrate-dev:
	docker compose --env-file .env.dev --compatibility --profile=migrate up -d --no-deps --remove-orphans --build
.PHONY: migrate-dev

migrate-prod:
	docker compose --env-file .env.prod --compatibility --profile=migrate up -d --no-deps --remove-orphans --build
.PHONY: migrate-prod

deploy-dev:
	docker compose --env-file .env.dev --compatibility --profile=dev up -d --no-deps --remove-orphans --build
.PHONY: deploy-dev

deploy-prod:
	docker compose --env-file .env.prod --compatibility --profile=prod up -d --no-deps --remove-orphans --build
.PHONY: deploy-prod

backup-dev:
	docker compose --env-file .env.dev --compatibility --profile=backup up -d --no-deps --remove-orphans --build
.PHONY: backup-dev

backup-prod:
	docker compose --env-file .env.prod --compatibility --profile=backup up -d --no-deps --remove-orphans --build
.PHONY: backup-prod

# %: - rule which match any task name; @: - empty recipe = do nothing
%:
	@:
