let expectedMinutesInOven = 40
let oneLayerPrepTime = 2;

func remainingMinutesInOven(elapsedMinutes: Int) -> Int {
    return expectedMinutesInOven - elapsedMinutes;                        
}

func preparationTimeInMinutes(layers: Int) -> Int {
    return layers * oneLayerPrepTime;                        
}

func totalTimeInMinutes(layers: Int, elapsedMinutes: Int) -> Int {
    return preparationTimeInMinutes(layers: layers) + elapsedMinutes;                        
}

//swift function with parameter
//how to call swift function with parameter
