# DigitalHive Technical Test (Anglo American)

## Instructions

Clone repository
```
git clone https://github.com/jcbdev/DigitalHive
```

Make sure you have all dependencies installed
- .NET 5
- NodeJS/Yarn
- Docker
- Python 3.x
- GNU Make (for running makefiles)

### Setup

1) Run docker container for postgres database
```
make db-up
```

2) Install all packages
```
make setup
```

3) Run tests
```
make test
```

4) Run ETL ingests and data seeding
```
make etls
```

### Running

Run API and dashboard
```
make run
```

Api is hosted at https://localhost:5001 (or 5000 for http)
Swagger documentation at https://localhost:5001/swagger

React front end dashboard is hosted at https://localhost:3000

db is preloaded with the follwing test users and roles
- User: james1, pwd: Password1, Role:Manager
- User: james2, pwd: Password1, Role:Trader
- User: james3, pwd: Password1, Role:Developer

you can also create your own user


