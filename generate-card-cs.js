const fs = require('fs');

const stackLength = 81;

const combinationCount = 3;

const cardsArray = [];
let index = 0;

const getStringByNumber = (number, strings) => {
  return strings[number];
}

for (let color = 0; color < combinationCount; color++) {
  for (let symbol = 0; symbol < combinationCount; symbol++) {
    for (let shading = 0; shading < combinationCount; shading++) {
      for (let number = 0; number < combinationCount; number++) {
        let colorString = getStringByNumber(color, ["Red", "Blue", "Green"]);
        let symbolString = getStringByNumber(symbol, ["Oval", "Squiggle", "Diamond"]);
        let shadingString = getStringByNumber(shading, ["Striped", "Solid", "Open"]);

        const cardString = `
      new CardDto
      {
        Id = ${index},
        Color = "${colorString}",
        Number = ${number + 1},
        Shading = "${shadingString}",
        Symbol = "${symbolString}"
      }`;
        cardsArray.push(cardString);
        index++;
      }
    }
  }
}

const cardsArrayString = cardsArray.toString();

fs.writeFileSync('./card.txt', cardsArrayString);