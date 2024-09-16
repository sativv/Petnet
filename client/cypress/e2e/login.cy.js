describe("User login", () => {
  it("should log in a user successfully", () => {
    cy.visit("http://localhost:3000/login");
    cy.get("form").should("be.visible");

    cy.get(":nth-child(2) > .login-input").type("private@private.private");
    // Fyll i lösenord
    cy.get(":nth-child(3) > .login-input").type("Private1!");
    cy.url().should("include", "/login");

    // Klicka på logga in-knappen
    cy.get(".login-button").click();
    // Användaren skickas till home
    cy.url().should("include", "/");

    // Kolla efter element som endast visas om man är innloggad
    cy.contains("Min profil");
    cy.contains("Logga ut");
  });
});
