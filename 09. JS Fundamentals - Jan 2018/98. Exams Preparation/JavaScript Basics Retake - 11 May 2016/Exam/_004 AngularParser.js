function angularParser(input) {

}

angularParser(['$app=\'MyApp\'',
    '$controller=\'My Controller\'&app=\'MyApp\'',
    '$model=\'My Model\'&app=\'MyApp\'',
    '$view=\'My View\'&app=\'MyApp\'',
]);

console.log('\n---\n');

angularParser(['$controller=\'PHPController\'&app=\'Language Parser\'',
    '$controller=\'JavaController\'&app=\'Language Parser\'',
    '$controller=\'C#Controller\'&app=\'Language Parser\'',
    '$controller=\'C++Controller\'&app=\'Language Parser\'',
    '$app=\'Garbage Collector\'',
    '$controller=\'GarbageController\'&app=\'Garbage Collector\'',
    '$controller=\'SpamController\'&app=\'Garbage Collector\'',
    '$app=\'Language Parser\''
]);