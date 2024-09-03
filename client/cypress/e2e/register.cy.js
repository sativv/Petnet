describe("New user private", () => {
  it("should register a new private user successfuly", () => {
    cy.visit("http://localhost:3000/register");

    cy.get('[type="email"]').type("private@private.private");
    // Fyll i lösenord
    cy.get("form > :nth-child(4)").type("Private1!");
    cy.get("form > :nth-child(6)").type("Private1!");

    // Klicka på logga in-knappen
    cy.get("#register-btn").click();

    // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
    cy.url().should("include", "/login");

    // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
    cy.contains("Logga in");
  });
});

describe("New user breeder", () => {
  it("should register a new breeder user successfuly", () => {
    cy.visit("http://localhost:3000/register");

    cy.get("label > input").check();

    cy.get('[type="email"]').type("breeder@breeder.breeder");
    // Fyll i lösenord
    cy.get("form > :nth-child(4)").type("Private1!");
    cy.get("form > :nth-child(6)").type("Private1!");
    //orgnr
    cy.get("form > :nth-child(8)").type("112233444");
    //företagnnamn
    cy.get("form > :nth-child(10)").type("Uppfödare AB");
    //kontakt
    cy.get("form > :nth-child(12)").type("Kalle P");
    //adress
    cy.get("form > :nth-child(14)").type("Uppfödargatan 3");
    //postnummer
    cy.get("form > :nth-child(16)").type("11122");
    //ort
    cy.get("form > :nth-child(18)").type("Swestad");
    //tel
    cy.get("form > :nth-child(20)").type("733-101010");

    //fil
    const fileName = "../fixtures/thinkbox2.png";
    cy.get('input[type="file"]').attachFile(fileName);

    cy.get("#register-btn").click();
    // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
    cy.url().should("include", "/login");

    // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
    cy.contains("Logga in");
  });
});
