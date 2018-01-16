function figureArea(w, h, W, H) {
    let area;
    let areaOne = w * h;
    let areaTwo = W * H;
    let areaMin = Math.min(w, W) * Math.min(h, H);
    area = areaOne + areaTwo - areaMin;

    console.log(area);
}

figureArea(2, 4, 5, 3);
