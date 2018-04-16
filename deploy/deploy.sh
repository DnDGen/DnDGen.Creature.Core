 
echo "Deploying DnDGen.Creature.Core to NuGet"

ApiKey=$1
Source=$2

echo "Nuget Source is $Source"
echo "Nuget API Key is $ApiKey (should be secure)"

echo "Listing bin directory"
for entry in "./DnDGen.Creature.Core/bin"/*
do
  echo "$entry"
done

echo "Packing DnDGen.Creature.Core"
nuget pack ./DnDGen.Creature.Core/DnDGen.Creature.Core.nuspec -Verbosity detailed

echo "Pushing DnDGen.Creature.Core"
nuget push ./DnDGen.Creature.Core.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source
