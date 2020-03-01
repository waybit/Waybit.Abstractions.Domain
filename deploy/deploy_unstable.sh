#!/usr/bin/env bash
API_KEY=$1
BUILD_NUMBER=$2

CONFIGURATION='Debug'
LATEST_TAG="$(git describe --tags --abbrev=0)"
VERSION="${LATEST_TAG}-unstable-${BUILD_NUMBER}"
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
