# Hotel Microservice

Bu projede iki mikroservis kullanılmıştır: Hotel ve Report

## Hotel 
 Bu mikroserviste MongoDb, .Net Core kullanılmıştır.
 
- Otel oluşturma,
- otel kaldırma,
- otel iletişim bilgisi ekleme,
- otel iletişim bilgisi kaldırma,
- otel ile ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi,
- otel yetkililerinin listelenmesi

  işlemlerini gerçekleştirmektedir.

  MongoDB'yi container olarak ayağa kaldırabilirsiniz.

Portainer: 
```bash
  docker volume create portainer_data
```
```bash
  docker run -d -p 9000:9000 -v /var/run/docker.sock:/var/run/docker.sock:z portainer/portainer
```
Portainer'a bağlanabilirsiniz
```bash
 localhost:9000
```
MongoDB:

Portainer'a bağlandıktan sonra App Templates alanından MongoDB seçin ve container ismi verin. Show advanced options alanından container port da yazan değeri host port'a da verin (`27017`) Deployment in progress'e tıklayın.

MongoDB Compass'ı bilgisayarınıza kurun.

MongoDB Compass'a bağlanmak için ` mongodb://localhost:27017`

Projeyi http'de çalıştırdıktan sonra URL'de `localhost:5011/swagger/index.html` giderek test edebilirisiniz

## VIDEO
<a href="https://github.com/feyzabakir/Hotel-Microservices/issues/4">Video Link</a>

## Report

RabbitMQ ve MongoDB kullanılmıştır. Api Gateway de Ocelot kütüphanesi kullanılmıştır.

`localhost:5012/swagger/index.html`


