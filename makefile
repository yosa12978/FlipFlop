PROJ = FlipFlop.MVC

run:
	dotnet run --project ./src/${PROJ}

watch:
	dotnet watch --project ./src/${PROJ}