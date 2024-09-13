describe("Logged in user should be able to post an add", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.get(":nth-child(2) > .login-input").type("user1@example.com");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("user1*123");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      cy.wait(2000);
      // Användaren skickas till home
      cy.url().should("include", "/");
    });
  });

  it("should be visable in my adds a list of my adds", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000);
    cy.contains("Ny annons").click();
    cy.url().should("include", "/addpost");
    cy.contains("Ladda upp annons").should("exist");

    cy.get("#title").should("exist").type("Igelkottsungar till salu");
    cy.get("#type").should("exist").select("Gnagare");
    cy.get("#breed").should("exist").type("Igelkott");
    cy.get("#gender").should("exist").select("Båda");
    cy.get('[type="date"][required=""]').should("exist").type("2024-09-10");
    cy.get('[min="2024-09-13"]').should("exist").type("2024-09-30");
    cy.get("#img")
      .should("exist")
      .type(
        "https://cdn3.cdnme.se/cdn/6-2/1468440/images/2010/igelkottar_92344891.jpg"
      );
    cy.get("#desc").should("exist").type("Söta små igelkottsungar, 50k/ st");

    cy.get(".login-button").should("exist").click();

    cy.url().should("include", "/post/");
    cy.get(".postTitle > .postInput[type=text]")
      .should("exist")
      .should("have.value", "Igelkottsungar till salu");
  });

  it("should be visable in my adds a list of my adds", () => {
    cy.visit("http://localhost:3000");

    cy.contains("Mina annonser").should("exist").click();
    cy.get(".bigAdContainer").should("exist").should("have.length", 2);

    cy.get(".bigAdSide > h3")
      .filter(':contains("Igelkott")')
      .should("have.length", 1);
  });
});

describe("Post-details page should be accessable when user is logged in", () => {
  beforeEach(() => {
    cy.session("user-session", () => {
      cy.visit("http://localhost:3000/login");
      cy.get(":nth-child(2) > .login-input").type("user1@example.com");
      // Fyll i lösenord
      cy.get(":nth-child(3) > .login-input").type("user1*123");
      // Klicka på logga in-knappen
      cy.get(".login-button").click();
      cy.wait(2000);
      // Användaren skickas till home
      cy.url().should("include", "/");
    });
  });

  it("should give you owner view when viewing details on your add", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000);
    cy.contains("Labrador").click();
    cy.url().should("include", "/post/1");

    const wordsCheck = [
      "Intressenter: ",
      "Spara Annons",
      "user1@example.com",
      "Djur",
      "Ras",
      "Kön",
      "Ålder",
      "Födelsedatum",
      "Tidigast Adoption",
    ];

    wordsCheck.forEach((w) => {
      cy.contains(w).should("exist");
    });

    cy.get(".postDetails")
      .should("exist")
      .should("contain", "Redigera Annons")
      .should("contain", "Ta Bort Annons");
  });

  it("should have options for editing your own add", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000);
    cy.contains("Igelkottsungar till salu").click();
    cy.url().should("include", "/post/");
    cy.get(".postDetails").should("exist").should("contain", "Redigera Annons");

    cy.contains("Redigera Annons").click();

    cy.get(".postInfo > :nth-child(1) > .postInput").select("Gnagare");
    cy.get(".postInfo > :nth-child(2) > .postInput").clear().type("Vädur");
    cy.get(".postInfo > :nth-child(3) > .postInput").select("Hona");
    cy.get(".postInfo > :nth-child(4) > .postInput").clear().type("1");
    cy.get(`.postInfo > :nth-child(5) > .postInput[type="date"]`).type(
      "2024-09-05"
    );
    cy.get(`.postInfo > :nth-child(6) > .postInput[type="date"]`).type(
      "2024-09-27"
    );
    cy.get(".postInfo > :nth-child(7) > .postInput")
      .clear()
      .type(
        "https://skvf.se/____impro/1/onewebmedia/info3.jpg?etag=%222b967-62853124%22&sourceContentType=image%2Fjpeg&ignoreAspectRatio&resize=500%2B332&extract=0%2B0%2B415%2B332&quality=85"
      );
    cy.get(".postDescription > .postInput")
      .clear()
      .type("Vacker liten vädurshona som söker ett kärleksfullt hem!");

    cy.contains("Spara Ändringar").click();
    cy.wait(1000);

    //Validera ändringarna

    //Lägg till test av avbryt ändringar
  });

  it("should ba able to register interest and save ad", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000);
    cy.contains("Siamese").click();
    cy.url().should("include", "/post/2");
    cy.get(".postDetails").should("exist");
    cy.contains("Skicka Intresseanmälan").should("exist").click();
    cy.contains("Spara Annons").should("exist").click();
  });

  it("should be visable in my adds as saved adds", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000);
    cy.contains("Mina annonser").click();
    cy.url().should("include", "/bookmarks");
    cy.contains("Dina Sparade Annonser").should("exist");
    cy.contains("Siamese").should("exist").click();
    cy.contains("Avbryt Intresseanmälan").should("exist").click();
    cy.contains("Spara Annons").should("exist").click();
    cy.contains("Skicka Intresseanmälan").should("exist");
  });

  it("should be visable in my adds a list of my adds", () => {
    cy.visit("http://localhost:3000");
    cy.wait(2000);
    cy.contains("Mina annonser").click();
    cy.url().should("include", "/bookmarks");
    cy.contains("Dina skapade annonser").should("exist");
    cy.contains("Vädur").should("exist");
  });
});
