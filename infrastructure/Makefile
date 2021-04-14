deploy:
	docker stack deploy -c docker-compose.yml postgres

takedown:
	docker stack rm postgres

run:
	docker-compose up -d

stop:
	docker-compose down --volumes

# docker swarm join --token SWMTKN-1-0z371w1g8q6hkqx6zs4nzjyflmlzxui6ttw7qwjarulvijdlyd-bdhujmlv4lbllz5roewl5e36f 192.168.99.100:2377∏