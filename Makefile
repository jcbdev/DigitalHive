run-db:
	cd infrastructure && ${MAKE} run

run-api:
	cd api && dotnet run

run-dashboard:
	cd dashboard && yarn start

run:
	${MAKE} -j 3 run-db run-api run-dashboard