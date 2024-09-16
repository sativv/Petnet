Cypress.on("uncaught:exception", (err, runnable) => {
  // Return false för att förhindra att testet misslyckas
  return false;
});

describe("User can logout if logged in desktop version", () => {
  it("should not have a logout button if not logged in", () => {
    cy.visit("http://localhost:3000");

    cy.get(".burgerIcon").should("not.be.visible");

    cy.get(".navbarMenu")
      .should("be.visible")
      .within(() => {
        cy.contains("Logga ut").should("not.exist");
        cy.contains("Logga in").should("exist");
      });

    // Klicka på "Logga in"-knappen
    cy.contains("Logga in").click();
    cy.wait(800);
    cy.url().should("include", "/login");
    cy.contains("Logga in");
  });

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

      // Kolla efter element som endast visas om man är innloggad
      cy.contains("Min profil");
      cy.contains("Logga ut");
    });
  });
  it("should log out a user successfully", () => {
    cy.visit("http://localhost:3000");

    cy.get(".burgerIcon").should("not.be.visible");

    cy.get(".navbarMenu")
      .should("be.visible")
      .within(() => {
        cy.contains("Logga in").should("not.exist");
        cy.contains("Logga ut").should("exist");
      });

    // Klicka på "Logga in"-knappen
    cy.contains("Logga ut").click();
    cy.wait(800);
    cy.url().should("include", "/");
    cy.contains("Sök");

    cy.get(".navbarMenu")
      .should("be.visible")
      .within(() => {
        cy.contains("Logga ut").should("not.exist");
        cy.contains("Logga in").should("exist");
        cy.contains("Registrering").should("exist");
      });
  });
});
