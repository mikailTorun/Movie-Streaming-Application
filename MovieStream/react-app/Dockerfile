# Node.js tabanlı bir Docker imajı kullanın
FROM node:alpine

# Uygulama kodunu çalıştırmak için bir çalışma dizini oluşturun
WORKDIR /app

# package.json ve package-lock.json'ı kopyalayın ve bağımlılıkları yükleyin
COPY package*.json ./
RUN npm install

# Tüm uygulama kodunu kopyalayın
COPY . .

# Uygulamayı çalıştırın
CMD ["npm", "start"]
