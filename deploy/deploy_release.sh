#!/usr/bin/env bash
API_KEY=$1
TAG=$2

CONFIGURATION='Release'
VERSION="${TAG}"
SLN_PATH="./src/Waybit.Abstractions.Domain.sln"

echo "Configuration: ${CONFIGURATION}"
echo "Version: ${VERSION}"

dotnet pack $SLN_PATH \
  -o "./" \
  -c $CONFIGURATION \
  -p:Version="$VERSION" \
  -p:IncludeSymbols=true \
  -p:SymbolPackageFormat=snupkg

dotnet nuget push "./Waybit.Abstractions.Domain.${VERSION}.nupkg" \
  -s "https://api.nuget.org/v3/index.json" \
  -k "$API_KEY"
