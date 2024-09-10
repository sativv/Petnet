describe("User login", () => {
  it("should log in a user successfully", () => {
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
