describe("User login", () => {
  it("should log in a user successfuly", () => {
    cy.visit("http://localhost:3000/login");

    cy.get(":nth-child(2) > .login-input").type("staffan@staffan.staffan");
    // Fyll i lösenord
    cy.get(":nth-child(3) > .login-input").type("Staffan1!");
    // Klicka på logga in-knappen
    cy.get(".login-button").click();
    // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
    cy.url().should("include", "/profile");

    // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
    cy.contains("Min profil");
  });
});
