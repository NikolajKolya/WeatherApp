# WeatherApp
App and site to show weather (lesson)

# Infrastructure
Build image: $ docker build -f dockerfile-weatherapp-infrastructure -t weatherapp-infrastructure-postgres .
Run container: $ docker-compose -f docker-compose-weatherapp-infrastructure.yml up -d

Комментарии:
docker build -f dockerfile-weatherapp-infrastructure -t weatherapp-infrastructure-postgres .

Создать образ контейнера (как образ диска с программами), используя инструкции из файла dockerfile-weatherapp-infrastructure
и дать имя получившемуся образу weatherapp-infrastructure-postgres


docker-compose -f docker-compose-weatherapp-infrastructure.yml up -d
Создать контейнеры (виртуальные компьютеры) по описанию из файла docker-compose-weatherapp-infrastructure.yml

Запустить контейнеры (виртуальные компьютеры): docker-compose -f docker-compose-weatherapp-infrastructure.yml up -d
Выключить контейнеры: docker-compose -f docker-compose-weatherapp-infrastructure.yml down

Для доступа через adminer используем следующие данные:
Адрес: http://127.0.0.1:9082/
Тип сервера: PostgreSQL
Адрес сервера: weatherapp-postgresql
Имя пользователя (администратора): postgres
Пароль: 7IoX80ggKRhJbLWoDIlde6M1frSQ5b
Имя базы данных: weatherapp