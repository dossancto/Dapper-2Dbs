run:
	dotnet run --project Two.UI

hot:
	dotnet watch run --project Two.UI

compose/up:
	docker compose up -d

compose/down:
	docker compose down

db/setup:
	echo "setup db"

db/update:
	echo "update db"

db/drop:
	echo "drop db"
