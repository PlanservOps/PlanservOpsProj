# Etapa de build
FROM node:22-alpine AS build
WORKDIR /app

COPY . .

RUN yarn install
RUN yarn build

# Etapa de produção com NGINX
FROM nginx:alpine

# Copia a build do Vite
COPY --from=build /app/dist /usr/share/nginx/html

# Copia a configuração do nginx personalizada
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
