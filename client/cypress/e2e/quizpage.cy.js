describe("Redirect to login when accessing quiz page", () => {
  it("should redirect to login page when trying to access quiz page without being logged in", () => {
    cy.visit("http://localhost:3000/quiz");
    // Skickas till inloggningssidan
    cy.url().should("include", "/login");

    cy.get("form").should("be.visible");

    cy.get(":nth-child(2) > .login-input").type("private@private.private");
    // Fyll i lösenord
    cy.get(":nth-child(3) > .login-input").type("Private1!");
    // Klicka på logga in-knappen
    cy.get(".login-button").click();
    // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
    cy.url().should("include", "/profile");

    // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
    cy.contains("Min profil");
  });
});

describe("Taking the quiz as a logged in user", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.get(":nth-child(2) > .login-input").type("private@private.private");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("Private1!");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
      cy.url().should("include", "/profile");

      // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
      cy.contains("Min profil");
    });
  });

  it("should give you a result based on your choices", () => {
    cy.visit("http://localhost:3000/quiz");
    // introduction
    cy.contains("Quiz");
    cy.get("button").click();

    //Question and different answers
    for (let i = 0; i < 15; i++) {
      cy.get("button").should("have.length", 7);

      cy.get(".quiz-cont-questions > :nth-child(7)").click(); // Klickar på den sista knappen
      cy.get(".counter-and-btn > button").click(); // Klickar på knappen "nästa"
    }

    //Result
    cy.contains(" skulle passa dig perfekt!");
    cy.get("button").click();
    cy.url().should("include", "/profile");

    //Borde lägga till koll för att se om resultatet syns på profilsidan som ett märke
  });
});
