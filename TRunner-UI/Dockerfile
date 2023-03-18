FROM node:16-alpine as builder
EXPOSE 80

WORKDIR /app
COPY . .

RUN npm i
RUN npm run build

FROM nginx:1.23.3-alpine

ENV NODE_ENV production
COPY --from=builder /app/build /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]