#!/bin/bash

echo "📁 Gyökérstruktúra létrehozása..."
mkdir -p ModularWebApp/{frontend,backend,shared/frontend/core.frontend.package,shared/frontend/ui.frontend.package,shared/backend/core.backend.package}
cd ModularWebApp

# 1. Backend microservice-ek
echo "🚀 Backend szolgáltatások létrehozása..."
cd backend
for service in panaszkezelo-api szerzodeskezelo-api ugyfelkezelo-api identity-api storage-api
do
  dotnet new webapi -n $service
done
cd ..

# 2. Közös backend csomag
echo "🧱 Közös backend könyvtár létrehozása..."
cd shared/backend/core.backend.package
dotnet new classlib -n Core.Backend.Package
cd ../../..

# 3. Angular frontend alkalmazások – host + remote modulok
echo "🌐 Angular frontend alkalmazások létrehozása..."
cd frontend

npm install -g @angular/cli

# Host létrehozása
ng new host --routing --style=scss --directory=host --standalone=false
cd host
ng add @angular-architects/module-federation --project host --type host --port 4200
cd ..

# Remote frontendek
for remote in panaszkezelo szerzodeskezelo ugyfelkezelo
do
  ng new $remote --routing --style=scss --directory=$remote --standalone=false
  cd $remote
  ng add @angular-architects/module-federation --project $remote --type remote --host host --port $((RANDOM % 1000 + 4300))
  cd ..
done
cd ..

# 4. Közös frontend csomag struktúra létrehozása
echo "🧰 Frontend közös könyvtárak létrehozása (npm init)..."
cd shared/frontend/core.frontend.package
npm init -y
cd ../ui.frontend.package
npm init -y
cd ../../../..

echo "✅ A moduláris projektstruktúra sikeresen létrehozva."