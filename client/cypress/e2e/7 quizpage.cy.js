describe("Redirect to login when accessing quiz page", () => {
  it("should redirect to login page when trying to access quiz page without being logged in", () => {
    cy.visit("http://localhost:3000/quiz");
    // Skickas till inloggningssidan
    cy.url().should("include", "/login");

    cy.get("form").should("be.visible");

    cy.get(":nth-child(2) > .login-input").type("user1@example.com");
    // Fyll i lösenord
    cy.get(":nth-child(3) > .login-input").type("user1*123");
    // Klicka på logga in-knappen
    cy.get(".login-button").click();
    // Användaren skickas till home
    cy.url().should("include", "/");
    cy.wait(2000);

    // Kolla efter element som endast visas om man är innloggad
    cy.contains("Min profil");
    cy.contains("Logga ut");
  });
});

describe("Taking the quiz as a logged in user", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.url().should("include", "/login");

      cy.get("form").should("be.visible");

      cy.get(":nth-child(2) > .login-input").type("user1@example.com");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("user1*123");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      // Användaren skickas till home
      cy.url().should("include", "/");
      cy.wait(2000);
      // Kolla efter element som endast visas om man är innloggad
      cy.contains("Min profil");
      cy.contains("Logga ut");
    });
  });

  it("should give you a result based on your choices", () => {
    cy.visit("http://localhost:3000/quiz");
    // introduction
    cy.contains("Quiz").should("exist");
    cy.get("button").click();

    //Question and different answers
    for (let i = 0; i < 15; i++) {
      cy.get("button").should("have.length", 7); //Kollar så att alla 6 svarsalternativ + nästa knapparna genereras

      cy.get(".quiz-cont-questions > :nth-child(7)").click(); // Klickar på den sista knappen
      cy.get(".counter-and-btn > button").click(); // Klickar på knappen "nästa"
    }

    //Result
    cy.contains(" skulle passa dig perfekt!").should("exist");
    cy.wait(2000);
    cy.get("button").click();
    cy.wait(2000);

    //Koll så att man skickats till rätt profilsida och att märket har lagts till
    cy.url().should("include", "/profile/user1");
    cy.get(".animal-badge").should("exist");
  });
});
