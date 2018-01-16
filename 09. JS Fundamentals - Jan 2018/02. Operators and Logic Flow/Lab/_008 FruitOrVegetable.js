function fruitOrVegetable(item) {
    let fruits = ['banana', 'apple', 'kiwi', 'cherry', 'lemon', 'grapes', 'peach'];
    let vegetable = ['tomato', 'cucumber', 'pepper', 'onion', 'garlic', 'parsley'];

    if (fruits.includes(item)) {
        console.log('fruit');
    }
    else if (vegetable.includes(item)) {
        console.log('vegetable');
    }
    else {
        console.log('unknown');
    }
}

fruitOrVegetable('kiwi');