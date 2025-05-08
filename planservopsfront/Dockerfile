# Etapa de build
FROM node:22-alpine AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY . .

# Recebe a variável como argumento de build
ARG VITE_API_URL

# Instala as dependências
RUN yarn install

# Gera a build
RUN yarn build

# Debug: Mostra o conteúdo da pasta dist
RUN echo "📁 Conteúdo da pasta /app/dist:" && ls -R /app/dist || echo " Pasta dist não encontrada"

# Etapa de produção com NGINX
FROM nginx:alpine

# Copia os arquivos da build gerada
COPY --from=build /app/dist /usr/share/nginx/html

# Copia a configuração customizada do NGINX
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Debug: Mostra o conteúdo final da pasta onde o NGINX busca os arquivos
RUN echo "📁 Conteúdo de /usr/share/nginx/html:" && ls -R /usr/share/nginx/html || echo " Nada em /usr/share/nginx/html"

EXPOSE 80

# Inicia o servidor NGINX
CMD ["nginx", "-g", "daemon off;"]
