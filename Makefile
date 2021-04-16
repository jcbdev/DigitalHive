
run-api:
	cd api/DigitalHive.Api && dotnet run

run-dashboard:
	cd dashboard && yarn start

run:
	killall -9 dotnet || true
	${MAKE} -j 3 run-api run-dashboard

db-up:
	cd infrastructure && docker-compose up -d

db-down:
	cd infrastructure && docker-compose down --volumes

setup:
	cd api && dotnet restore
	cd api/DigitalHive.Api && dotnet ef database update
	cd dashboard && yarn
	cd etl-jobs && \
		python3 -m venv .venv && \
		source ./.venv/bin/activate && \
		pip install -r requirements.txt

test:
	killall -9 dotnet || true
	cd api && dotnet test
	cd api/DigitalHive.Api && dotnet run &
	sleep 5
	cd dashboard && JEST_JASMINE=1 yarn jest
	cd etl-jobs && source ./.venv/bin/activate && pytest
	killall -9 dotnet || true

etls:
	killall -9 dotnet || true
	cd api/DigitalHive.Api && dotnet run &
	sleep 5
	cd etl-jobs && \
		source ./.venv/bin/activate && \
		python clear.py && \
		python seedusers.py && \
		python models.py && \
		python stitch.py
