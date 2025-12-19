# Etapa 1: Construcción de la aplicación con Vite
FROM node:18 AS build
WORKDIR /app

# Copiar solo package.json y package-lock.json primero (mejor cache)
COPY package*.json ./

# Instalar dependencias
RUN npm install

# Copiar el proyecto completo
COPY . .

# Construir la aplicación
RUN npm run build

FROM nginx:alpine

COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
