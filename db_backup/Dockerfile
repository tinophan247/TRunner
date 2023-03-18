FROM alpine:3.15
RUN apk add --update openssl mysql-client curl
RUN apk add --no-cache mariadb-connector-c

COPY . .

RUN chmod +x backup.sh
ENTRYPOINT ["./backup.sh"]