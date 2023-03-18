#!/bin/sh

echo "starting mysqldump"
day=$(date '+%Y%m%d%H%M%S')
db_backup="runner_${day}.sql.gz"
mysqldump --no-tablespaces --host=database --port=3306 \
    --user=${MYSQL_USER} --password=${MYSQL_PASSWORD} \
    --default-auth=mysql_native_password \
    --databases ${MYSQL_DATABASE}  | gzip > /backup/${db_backup}
echo "mysqldump complete"