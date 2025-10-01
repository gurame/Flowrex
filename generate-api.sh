#!/bin/bash
# Script para generar PublicAPI.txt automáticamente

echo "🔍 Generando PublicAPI.txt para Flowrex.Abstractions..."

# Compilar y capturar errores RS0016
dotnet build src/Flowrex.Abstractions --verbosity quiet 2>&1 | \
grep "RS0016" | \
sed -E "s/.*Symbol '([^']+)'.*/\1/" | \
sort -u > temp_symbols.txt

echo "🔧 Símbolos encontrados:"
cat temp_symbols.txt

echo ""
echo "📝 Agregando símbolos al PublicAPI.Unshipped.txt..."
echo "#nullable enable" > src/Flowrex.Abstractions/PublicAPI.Unshipped.txt

# Aquí agregaremos las firmas manualmente basándonos en los símbolos
echo "✅ Listo! Ahora necesitas ejecutar el script y revisar los símbolos."

# Limpiar
rm -f temp_symbols.txt