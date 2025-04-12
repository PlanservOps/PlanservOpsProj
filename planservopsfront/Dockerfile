# Etapa de build
FROM node:22-alpine AS build
WORKDIR /app

COPY . .

RUN yarn install
RUN yarn build

# Etapa de produção com NGINX
FROM nginx:alpine

# Copia os arquivos da build para o NGINX
COPY --from=build /app/dist /usr/share/nginx/html

# Copia uma configuração personalizada do nginx (pra SPA com rotas)
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
