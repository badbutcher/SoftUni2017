function personalBMI(name, age, weight, height) {
    let result = {};
    let bmi = Math.round(weight / Math.pow(height / 100, 2));
    let status = getStatus(bmi);
    result.name = name;
    result.personalInfo = {};
    result.personalInfo.age = age;
    result.personalInfo.weight = weight;
    result.personalInfo.height = height;
    result.BMI = bmi;
    result.status = status;
    if (status === 'obese') {
        result.recommendation = 'admission required';
    }

    return result;

    function getStatus(bmi) {
        if (bmi > 30) {
            return 'obese'
        } else if (bmi < 18.5) {
            return 'underweight'
        } else if (bmi < 25) {
            return 'normal'
        } else if (bmi < 30) {
            return 'overweight'
        }
    }
}

personalBMI('Honey Boo Boo', 29, 75, 182);