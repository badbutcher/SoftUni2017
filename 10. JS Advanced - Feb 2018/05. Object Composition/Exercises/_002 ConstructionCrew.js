function constructionCrew(input) {
    if (input.handsShaking) {
        let levelToAdd = input.weight * input.experience * 0.1;
        input.bloodAlcoholLevel += levelToAdd;
        input.handsShaking = false;
        return input;
    }
    else {
        return input;
    }
}

constructionCrew({
        weight: 120,
        experience: 20,
        bloodAlcoholLevel: 200,
        handsShaking: true
    }
);