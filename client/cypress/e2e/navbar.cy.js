describe("Navbar for user not logged in", () => {
  it("should have links and user should get redirected on pages that are locked", () => {
    cy.viewport("iphone-6");
    cy.visit("http://localhost:3000");

    const stringsToCheck = [
      "Hemsida",
      "Quiz",
      "Ny annons",
      "Sök profil",
      "Bokmärken",
      "Registrering",
      "Logga in",
    ];

    cy.get(".burgerIcon").click();
    stringsToCheck.forEach((str) => {
      cy.contains(str).should("exist");
    });

    cy.get('.navbarMenu > [href="/"]').click();
    cy.url().should("include", "/");

    cy.get(".burgerIcon").click();
    cy.get('.navbarMenu > [href="/quiz"]').should("be.visible").click();
    cy.url().should("include", "/login");
    cy.contains("Logga in");
    cy.url().should("not.contain", "/quiz");

    cy.get(".burgerIcon").click();
    cy.get('[href="/addpost"]').should("be.visible").click();
    cy.url().should("include", "/login");
    cy.contains("Logga in");
    cy.url().should("not.contain", "/addpost");

    cy.get(".burgerIcon").click();
    cy.get('[href="/profileSearch"]').should("be.visible").click();
    cy.url().should("include", "/profileSearch");
    cy.contains("Användarregister");

    cy.get(".burgerIcon").click();
    cy.get('[href="/bookmarks"]').should("be.visible").click();
    cy.url().should("include", "/login");
    cy.contains("Logga in");
    cy.url().should("not.contain", "/bookmarks");

    cy.get(".burgerIcon").click();
    cy.get('.navbarMenu > [href="/register"]').should("be.visible").click();
    cy.url().should("include", "/register");
    cy.url().should("not.contain", "/login");

    cy.get(".burgerIcon").click();
    cy.get('.navbarMenu > [href="/login"]').should("be.visible").click();
    cy.url().should("include", "/login");
    cy.contains("Logga in");
  });
});

describe("Navbar for user logged in", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.get(":nth-child(2) > .login-input").type("user1@example.com");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("user1*123");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      cy.wait(500);
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      // Verifiera att användaren är omdirigerad till dashboard eller en annan skyddad sida
      cy.url().should("include", "/profile");

      // Verifiera att en viss text eller element finns på sidan, vilket bekräftar att användaren är inloggad
      cy.contains("Min profil");
    });
  });
  it("should have links and user should get access to all pages in navbar", () => {
    cy.viewport("iphone-6");
    cy.visit("http://localhost:3000");

    const stringsToCheck = [
      "Hemsida",
      "Quiz",
      "Ny annons",
      "Sök profil",
      "Bokmärken",
      "Min profil",
      "Logga ut",
    ];

    cy.get(".burgerIcon").click();
    stringsToCheck.forEach((str) => {
      cy.contains(str).should("exist");
    });

    cy.get('.navbarMenu > [href="/"]').click();
    cy.wait(500);
    cy.url().should("include", "/");

    cy.get(".burgerIcon").click();
    cy.get('.navbarMenu > [href="/quiz"]').should("be.visible").click();
    cy.url().should("include", "/quiz");
    cy.contains("Quiz");
    cy.url().should("not.contain", "/login");

    cy.get(".burgerIcon").click();
    cy.get('[href="/addpost"]').should("be.visible").click();
    cy.url().should("include", "/addpost");
    cy.contains("Ladda upp annons");
    cy.url().should("not.contain", "/login");

    cy.get(".burgerIcon").click();
    cy.get('[href="/profileSearch"]').should("be.visible").click();
    cy.url().should("include", "/profileSearch");
    cy.contains("Användarregister");
    cy.wait(500);

    cy.get(".burgerIcon").click();
    cy.get('[href="/bookmarks"]').should("be.visible").click();
    cy.wait(500);
    cy.url().should("include", "/bookmarks");
    cy.contains("Dina Sparade Annonser");
    cy.url().should("not.contain", "/login");

    cy.get(".burgerIcon").click();
    cy.get(".navbarMenu > :nth-child(6)").should("be.visible").click();
    cy.wait(800);
    cy.url().should("include", "/profile/user1");
    cy.contains("Min profil");
    cy.contains("user1@example.com");
    cy.contains("user1@example.com");
    cy.get(".badge-img");
    cy.url().should("not.contain", "/login");

    cy.contains("Logga ut");
    cy.get(".navbarMenu > :nth-child(7)").should("be.visible").click();
    cy.url().should("include", "/login");
    cy.contains("Logga in");
  });
});
