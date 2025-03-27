#!/bin/bash

# Alap könyvtár létrehozása
mkdir -p ModularWebApp && cd ModularWebApp

echo "📁 Projektstruktúra létrehozása..."

# 1. Backend microservice-ek
echo "🚀 Backend szolgáltatások létrehozása..."
dotnet new sln -n ModularWebApp

for service in panaszkezelo szerzodeskezelo ugyfelkezelo identity storage
do
  dotnet new webapi -n ${service}-api
  dotnet sln add ${service}-api/${service}-api.csproj
done

# 2. Backend közös könyvtár
echo "🧱 Közös backend könyvtár létrehozása..."
dotnet new classlib -n core.backend.package
dotnet sln add core.backend.package/core.backend.package.csproj

# 3. Frontend Angular host alkalmazás
echo "🌐 Angular host alkalmazás létrehozása..."
npm install -g @angular/cli
ng new host --routing --style=scss
cd host
ng add @angular-architects/module-federation --project host --type host --port 4200
cd ..

# 4. Angular remote alkalmazások
echo "🌐 Angular remote alkalmazások létrehozása..."
for frontend in panaszkezelo szerzodeskezelo ugyfelkezelo
do
  ng new $frontend --routing --style=scss
  cd $frontend
  ng add @angular-architects/module-federation --project $frontend --type remote --host host --port $((RANDOM % 1000 + 4201))
  cd ..
done

# 5. Frontend közös könyvtárak
echo "🧰 Frontend közös könyvtárak létrehozása..."
mkdir -p shared/frontend/core.frontend.package
mkdir -p shared/frontend/ui.frontend.package

echo "✅ Kész! A projektstruktúra generálása sikeresen befejeződött."