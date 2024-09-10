describe("User can logout if logged in", () => {
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
    cy.contains("Logga in");

    //  cy.get(".burgerIcon").click();
    //  cy.get('.navbarMenu > [href="/login"]').should("be.visible").click();
    //  cy.url().should("include", "/login");
    //  cy.contains("Logga in");
  });

  // it("should log out a user successfully", () => {
  //   cy.visit("http://localhost:3000/login");

  //   cy.get(":nth-child(2) > .login-input").type("private@private.private");
  //   // Fyll i lösenord
  //   cy.get(":nth-child(3) > .login-input").type("Private1!");
  //   // Klicka på logga in-knappen
  //   cy.get(".login-button").click();
  //   // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
  //   cy.url().should("include", "/profile");

  //   // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
  //   cy.contains("Min profil");
  // });
});
