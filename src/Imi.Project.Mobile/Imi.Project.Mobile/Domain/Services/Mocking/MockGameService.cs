using FreshMvvm;
using Imi.Project.Mobile.Domain.Models;
using Imi.Project.Mobile.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking
{
    public class MockGameService : IGamesService
    {
        private static List<Game> gameList = new List<Game>
        {
            new Game{
                Id = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"),
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                OpeningId = Guid.Parse("b74f5dcc-4adf-4fc2-8bba-098ef36cf75f"),
                Opening = new Opening
                {
                    Id = Guid.Parse("b74f5dcc-4adf-4fc2-8bba-098ef36cf75f"),
                    Name = "King's Indian defence",
                    Moves = new List<OpeningMove>{
                        new OpeningMove { Id = Guid.Parse("d6523c30-99df-4077-b036-5ea325d19b8d"), OpeningId = Guid.Parse("b74f5dcc-4adf-4fc2-8bba-098ef36cf75f"), MovePGN = "d4", Turn = 1 },
                        new OpeningMove { Id = Guid.Parse("623393bd-0e0c-4b31-bcb7-7208313f24f2"), OpeningId = Guid.Parse("b74f5dcc-4adf-4fc2-8bba-098ef36cf75f"), MovePGN = "Nf6", Turn = 2 },
                        new OpeningMove { Id = Guid.Parse("54f4d7d2-8d3f-4e5a-be3f-9d20acef71af"), OpeningId = Guid.Parse("b74f5dcc-4adf-4fc2-8bba-098ef36cf75f"), MovePGN = "c4", Turn = 3 },
                        new OpeningMove { Id = Guid.Parse("733673a0-4aca-4c40-8aa6-956d95cca7af"), OpeningId = Guid.Parse("b74f5dcc-4adf-4fc2-8bba-098ef36cf75f"), MovePGN = "g6", Turn = 4 }
                    }
                },
                Name = "Nakamaru vs bellaiche game",
                BugMessage = "",
                IsBugged = false,
                DateAdded = DateTime.Now.Date,
                Outcome = "Win",
                PlayedAs = "White",
                Moves = new List<GameMove>
                {
                     new GameMove { Id = Guid.Parse("8f845dd7-09e8-441f-be22-e8cd8e59b66f"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "d4", Turn = 1, Annotation = "d4 opening" },
                    new GameMove { Id = Guid.Parse("af29e2d1-6acb-4c4c-af9a-cd2cf153c027"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nf6", Turn = 2, Annotation = "Wow!" },
                    new GameMove { Id = Guid.Parse("81b08851-0e43-4566-90c4-fd429309ec6a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "c4", Turn = 3 },
                    new GameMove { Id = Guid.Parse("ec38ac9e-3bb7-439b-8826-ea42c6c6151e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "g6", Turn = 4 },
                    new GameMove { Id = Guid.Parse("b8e30a7b-cba1-486c-b6dc-dae5d6490a3e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nc3", Turn = 5 },
                    new GameMove { Id = Guid.Parse("2b347f65-c77e-45fd-b8dd-bcc257c2dc3a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bg7", Turn = 6 , Annotation = "Cool man!"},
                    new GameMove { Id = Guid.Parse("c3caa268-50c5-470f-84b1-384892e36478"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "e4", Turn = 7 },
                    new GameMove { Id = Guid.Parse("db6eed1b-7c60-49b9-88e6-ea9bcec02d22"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "d6", Turn = 8 },
                    new GameMove { Id = Guid.Parse("70eb91fd-1410-4e76-8743-e0c30471af04"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nf3", Turn = 9 , Annotation = "Wat een move"},
                    new GameMove { Id = Guid.Parse("c9f99cf3-e5eb-43ad-aeb4-0cc85e7f4a3e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "O-O", Turn = 10 },
                    new GameMove { Id = Guid.Parse("e1555217-f011-4f64-a38b-b5d3f36303fd"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Be2", Turn = 11 },
                    new GameMove { Id = Guid.Parse("2a5b54cc-b971-4da6-a116-12dd798309ee"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "e5", Turn = 12 },
                    new GameMove { Id = Guid.Parse("5bbf17c2-8046-4393-bf42-46c90b6efd5d"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "O-O", Turn = 13 },
                    new GameMove { Id = Guid.Parse("4dbeea8b-e18d-4e7a-873c-8f125882115b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nc6", Turn = 14 },
                    new GameMove { Id = Guid.Parse("05cdaeac-2848-4b0c-86c8-0cb841fa034f"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "d5", Turn = 15 },
                    new GameMove { Id = Guid.Parse("009229ba-09f9-41e0-aa03-e41d2e7885b5"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ne7", Turn = 16 },
                    new GameMove { Id = Guid.Parse("584847aa-dddf-442d-938a-f42087ef0ebf"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "b4", Turn = 17 },
                    new GameMove { Id = Guid.Parse("96b20da9-587a-423d-8bff-2ffbe0b5aa24"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nh5", Turn = 18 },
                    new GameMove { Id = Guid.Parse("7d077b66-b1a4-44ae-9045-1b2c76841ab4"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Re1", Turn = 19 },
                    new GameMove { Id = Guid.Parse("a2903177-1a7e-412d-bc17-640e479ad524"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nf4", Turn = 20 },
                    new GameMove { Id = Guid.Parse("a2283cd3-c213-4713-854d-d1887455cc47"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bf1", Turn = 21 },
                    new GameMove { Id = Guid.Parse("a09ae993-da24-4541-a91b-17cd79182fa3"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "f5", Turn = 22 },
                    new GameMove { Id = Guid.Parse("b8000217-f057-42f4-95d4-b0ea08cdc2f9"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bxf4", Turn = 23 },
                    new GameMove { Id = Guid.Parse("e9d31ece-54c7-4453-8a44-2ad9158d4263"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "exf4", Turn = 24 },
                    new GameMove { Id = Guid.Parse("a352107f-196d-45e0-a3d2-5a65d199060c"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "e5", Turn = 25 },
                    new GameMove { Id = Guid.Parse("d3fa478d-5302-429e-96ea-8c5777847c6d"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "h6", Turn = 26 },
                    new GameMove { Id = Guid.Parse("5ca73ccc-d897-418c-bae2-4d107685acbf"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qd2", Turn = 27 },
                    new GameMove { Id = Guid.Parse("d6637c29-58da-41f3-9338-04bc278ebaa6"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "g5", Turn = 28 },
                    new GameMove { Id = Guid.Parse("d591475c-e469-4342-84b1-412daa9b1033"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "exd6", Turn = 29 },
                    new GameMove { Id = Guid.Parse("3eda7d9d-0d71-4275-bfa3-b74f3895ae4f"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "cxd6", Turn = 30 },
                    new GameMove { Id = Guid.Parse("b7c4e6e9-8166-4b06-8447-33ebecba5f41"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nd4", Turn = 31 },
                    new GameMove { Id = Guid.Parse("56e16b7d-957b-403c-aa24-3f97fed0e7dd"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ng6", Turn = 32 },
                    new GameMove { Id = Guid.Parse("a4cbb977-116a-4dc9-8b4f-c0a55df5926a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rad1", Turn = 33 },
                    new GameMove { Id = Guid.Parse("26eed230-00b0-4574-a6fc-a480088b85dc"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ne5", Turn = 34 },
                    new GameMove { Id = Guid.Parse("1bf3d29e-982b-4e24-a948-859102b98a2e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "c5", Turn = 35 },
                    new GameMove { Id = Guid.Parse("8aafe319-90ab-474a-8b03-d90fa4da762c"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "a5", Turn = 36 },
                    new GameMove { Id = Guid.Parse("18cf821c-391a-4bd8-bfe5-6da651f89c11"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "a3", Turn = 37 },
                    new GameMove { Id = Guid.Parse("ddd58640-8677-4b7b-8852-3bf6eeefbd6c"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "axb4", Turn = 38 },
                    new GameMove { Id = Guid.Parse("18cdf31e-7dcf-4835-9320-57793f1f7e90"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "axb4", Turn = 39 },
                    new GameMove { Id = Guid.Parse("42cbd085-81a4-4dd8-8ba9-dab0df7a803b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qf6", Turn = 40 },
                    new GameMove { Id = Guid.Parse("a3d7810f-58fb-41c8-b6c7-a6b295e7217d"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ncb5", Turn = 41 },
                    new GameMove { Id = Guid.Parse("7ea4abb7-b9d4-482d-9414-9a9ac921a79f"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "dxc5", Turn = 42 },
                    new GameMove { Id = Guid.Parse("613b6942-76f0-44fa-bb31-e25a92043799"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "bxc5", Turn = 43 },
                    new GameMove { Id = Guid.Parse("1e6a9a9d-0657-42bb-a732-15e5ff5b9b66"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bd7", Turn = 44 },
                    new GameMove { Id = Guid.Parse("4022c625-09a9-4490-988d-f23ab71d10de"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nc7", Turn = 45 },
                    new GameMove { Id = Guid.Parse("b1b7b4fc-decc-455c-ad51-439faefc6f3e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rac8", Turn = 46 },
                    new GameMove { Id = Guid.Parse("a96495df-6b16-43ae-8485-fa7cd8a339fc"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "d6", Turn = 47 },
                    new GameMove { Id = Guid.Parse("0cb22d2f-0624-4eb4-9443-74e7c651e6ed"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "b6", Turn = 48 },
                    new GameMove { Id = Guid.Parse("eb88043f-d54d-44cd-b5f0-7936e8195eda"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nd5", Turn = 49 },
                    new GameMove { Id = Guid.Parse("52e526a7-5b27-48b5-8861-9ea10c8dfd3b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qf7", Turn = 50 },
                    new GameMove { Id = Guid.Parse("0ef690da-1ce9-43f6-a0fa-57ddff13c5c4"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ne7+", Turn = 51 },
                    new GameMove { Id = Guid.Parse("9c6e6542-bc91-457e-8f49-fc678cb05ea6"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kh8", Turn = 52 },
                    new GameMove { Id = Guid.Parse("077e3129-8dbf-4124-ba24-1e793569e391"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nxc8", Turn = 53 },
                    new GameMove { Id = Guid.Parse("8a5bdeaf-b4b7-4a5b-92a8-cd63b92b3112"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "bxc5", Turn = 54 },
                    new GameMove { Id = Guid.Parse("352a5249-5036-476d-93aa-2dbe8fc5591a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nf3", Turn = 55 },
                    new GameMove { Id = Guid.Parse("a2944e7e-fa5e-46cc-a6c8-7f39ba386ad1"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nxf3+", Turn = 56 },
                    new GameMove { Id = Guid.Parse("c327e201-281d-4fda-b224-ead1d0a99b9e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "gxf3", Turn = 57 },
                    new GameMove { Id = Guid.Parse("c68f6d8c-e144-4ff0-8706-bd74bca24361"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bc6", Turn = 58 },
                    new GameMove { Id = Guid.Parse("897a720d-2456-4e2d-870d-b571e45af833"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ne7", Turn = 59 },
                    new GameMove { Id = Guid.Parse("ce4a0df6-e83a-4ab8-9aec-98f06c86cd18"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bxf3", Turn = 60 },
                    new GameMove { Id = Guid.Parse("a8482897-f477-4f55-8b92-b8e8ca7307e9"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Be2", Turn = 61 },
                    new GameMove { Id = Guid.Parse("181f8e70-44d1-4677-a018-09f4afba23ca"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bb7", Turn = 62 },
                    new GameMove { Id = Guid.Parse("1ad1bc58-3c16-4434-91f6-5facfe748216"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qd3", Turn = 63 },
                    new GameMove { Id = Guid.Parse("e0a2b016-c079-46e7-aa6c-ddc428e12a44"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "g4", Turn = 64 },
                    new GameMove { Id = Guid.Parse("4e49fd9e-fbd4-4098-94e2-830c10ab6b17"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qxf5", Turn = 65 },
                    new GameMove { Id = Guid.Parse("dcae262b-fc23-45cd-b3e9-390707246373"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qxf5", Turn = 66 },
                    new GameMove { Id = Guid.Parse("3ea113d4-6421-4c99-b1bb-8afb5b894d3b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Nxf5", Turn = 67 },
                    new GameMove { Id = Guid.Parse("31d741aa-bf28-4646-b9ea-ac7cc17a6867"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rxf5", Turn = 68 },
                    new GameMove { Id = Guid.Parse("ec8d4046-8ce6-4f24-ba17-b9db0e54b646"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "d7", Turn = 69 },
                    new GameMove { Id = Guid.Parse("550d3c77-3806-4ab8-970d-bd2986c53ee3"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bf6", Turn = 70 },
                    new GameMove { Id = Guid.Parse("fe49b1fe-aa7d-4de9-b269-915368c266e2"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "d8=Q+", Turn = 71 },
                    new GameMove { Id = Guid.Parse("79fc168c-4dd0-4941-a116-86f730a9bf30"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bxd8", Turn = 72 },
                    new GameMove { Id = Guid.Parse("03eb5309-af71-42ab-abc0-9893af704b8f"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rxd8+", Turn = 73 },
                    new GameMove { Id = Guid.Parse("a738a6ea-2711-4117-ae8d-3c5e7e7dbf2b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kg7", Turn = 74 },
                    new GameMove { Id = Guid.Parse("95e0cb0e-13ae-4066-b471-d28ed6754050"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rd7+", Turn = 75 },
                    new GameMove { Id = Guid.Parse("d6436677-1535-4725-bcb9-bbbc79e56919"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rf7", Turn = 76 },
                    new GameMove { Id = Guid.Parse("b6a93732-bc83-4111-9951-e687fba74752"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rxf7+", Turn = 77 },
                    new GameMove { Id = Guid.Parse("bf0680a9-8ff1-40ff-aed7-743a3cb26a70"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kxf7", Turn = 78 },
                    new GameMove { Id = Guid.Parse("4f76852b-46dd-4d6c-beaf-c064f8cc2e38"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bxg4", Turn = 79 },
                    new GameMove { Id = Guid.Parse("667be700-ea13-46ae-a91b-e10470a77625"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "c4", Turn = 80 },
                    new GameMove { Id = Guid.Parse("c62cc213-2f59-407d-add7-c33e62cddd6e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rc1", Turn = 81 },
                    new GameMove { Id = Guid.Parse("8ca2cea3-9b07-4861-ba4e-9d9488236a82"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bd5", Turn = 82 },
                    new GameMove { Id = Guid.Parse("5216f5f8-add5-44f2-b808-3d89ff1da52b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Be2", Turn = 83 },
                    new GameMove { Id = Guid.Parse("2d0d3178-396e-4afb-90c0-6e0379f450ef"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kf6", Turn = 84 },
                    new GameMove { Id = Guid.Parse("c97d1efe-cb75-432f-8d41-f52ba3c13a19"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bxc4", Turn = 85 },
                    new GameMove { Id = Guid.Parse("24e81463-ae4b-467c-b99d-b282986c7767"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Be4", Turn = 86 },
                    new GameMove { Id = Guid.Parse("02f71003-1fc8-4b4f-abee-df9f89776f15"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Re1", Turn = 87 },
                    new GameMove { Id = Guid.Parse("aec140da-fc89-450a-aa75-98e44605566a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bf5", Turn = 88 },
                    new GameMove { Id = Guid.Parse("46ed6827-f85e-49f4-9471-d6aac2b07083"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "f3", Turn = 89 },
                    new GameMove { Id = Guid.Parse("22a37e0d-fc32-47a3-b32a-1f23522431e9"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "h5", Turn = 90 },
                    new GameMove { Id = Guid.Parse("3be0336d-7fc3-46be-9a32-ccc6ed310dbc"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "h4", Turn = 91 },
                    new GameMove { Id = Guid.Parse("71f47353-92f4-4dcd-998e-f79141b1489b"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kg6", Turn = 92 },
                    new GameMove { Id = Guid.Parse("1a8ebe2f-bc7a-4b16-a74e-e88b6bd17d33"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kg2", Turn = 93 },
                    new GameMove { Id = Guid.Parse("5e149c46-04de-44e6-af7c-bce5eec11b7f"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kf6", Turn = 94 },
                    new GameMove { Id = Guid.Parse("f6a8833f-4b2d-4bd0-b05f-02dab66a2740"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Re8", Turn = 95 },
                    new GameMove { Id = Guid.Parse("bfb0f318-004d-43d0-9020-0ec6aee7af95"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bd7", Turn = 96 },
                    new GameMove { Id = Guid.Parse("b877d7d7-2cd6-4389-94c4-bac2422afee0"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rh8", Turn = 97 },
                    new GameMove { Id = Guid.Parse("5243a031-4f70-4705-aeaf-7c1b58001233"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kg6", Turn = 98 },
                    new GameMove { Id = Guid.Parse("686a7a05-fac6-41a6-b2f0-a179ff95450c"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bd3+", Turn = 99 },
                    new GameMove { Id = Guid.Parse("9c36eeec-c67f-48bb-9ae2-dc03fdd5867a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kf6", Turn = 100 },
                    new GameMove { Id = Guid.Parse("7c47f0bb-1204-48c8-9c1c-fcfc73151fc4"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rxh5", Turn = 101 },
                    new GameMove { Id = Guid.Parse("e459a962-89a6-4391-9639-ba7becb1d531"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kg7", Turn = 102 },
                    new GameMove { Id = Guid.Parse("ce3a03e1-a613-4343-9914-8326281e01e5"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rg5+", Turn = 103 },
                    new GameMove { Id = Guid.Parse("60b6c605-318c-4fae-954b-13054ea679f0"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kf6", Turn = 104 },
                    new GameMove { Id = Guid.Parse("9d8b48a1-590f-4aae-b6e0-0c74229822b7"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Be4", Turn = 105 },
                    new GameMove { Id = Guid.Parse("f31aa6e3-e3e9-4a83-94d4-ebb52309e2fd"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bc8", Turn = 106 },
                    new GameMove { Id = Guid.Parse("3c9724a5-c200-4255-adfb-c5564effdb00"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rg4", Turn = 107 },
                    new GameMove { Id = Guid.Parse("dda89252-3534-4eb3-9a01-c1d42a59e6a8"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ke5", Turn = 108 },
                    new GameMove { Id = Guid.Parse("2f25ceea-41b9-42f1-bc1b-5d3fcce8be7c"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Rg8", Turn = 109 },
                    new GameMove { Id = Guid.Parse("0d2d0757-9150-45c2-b3d4-424f6f60eb50"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bd7", Turn = 110 },
                    new GameMove { Id = Guid.Parse("4dc7e39d-30bf-4816-a6a6-c5513f5bb20a"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "h5", Turn = 111 },
                    new GameMove { Id = Guid.Parse("fff5f98d-207e-4aa6-90d6-ec96f86fbb5e"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kf6", Turn = 112 },
                    new GameMove { Id = Guid.Parse("e516572a-6bc5-41c2-814d-57c717c798e7"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "h6", Turn = 113 },
                    new GameMove { Id = Guid.Parse("d50eaa06-32d5-4b53-8203-8b5de24c5323"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Be6", Turn = 114 },
                    new GameMove { Id = Guid.Parse("c7e05c9a-0866-4ba9-867d-2ace9b48a306"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "h7", Turn = 115 },
                    new GameMove { Id = Guid.Parse("3bce0f17-4f5a-4306-bb22-79b0ca978f90"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Bxg8", Turn = 116 },
                    new GameMove { Id = Guid.Parse("0f45448c-b910-4eea-9579-d4b4b243e440"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "hxg8=Q", Turn = 117 },
                    new GameMove { Id = Guid.Parse("a43a0978-baf8-4f85-92f0-3103044d55ea"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Ke7", Turn = 118 },
                    new GameMove { Id = Guid.Parse("0bee489f-13dd-4c02-9722-cbff2115c661"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Qg4", Turn = 119 },
                    new GameMove { Id = Guid.Parse("e6bfa023-735c-4da4-849e-d2e0e03eec96"), GameId = Guid.Parse("936f23fa-fcd5-4d58-8c3c-39081fb548a0"), MovePGN = "Kf6", Turn = 120 },
                }
            }

            ,
            new Game{
                Id = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"),
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                OpeningId = Guid.Parse("7715553b-fe8b-4a7e-88a3-36a1d023dc8b"), //French defence
                Opening = new Opening
                {
                    Id = Guid.Parse("7715553b-fe8b-4a7e-88a3-36a1d023dc8b"),
                    Name = "French defence",
                    Moves = new List<OpeningMove>{
                        new OpeningMove { Id = Guid.Parse("617b0463-dfe5-4df9-87f5-2111f7847938"), OpeningId = Guid.Parse("7715553b-fe8b-4a7e-88a3-36a1d023dc8b"), MovePGN = "e4", Turn = 1 },
                        new OpeningMove { Id = Guid.Parse("bf0f890b-bd68-482a-9e3b-4eb579e259c6"), OpeningId = Guid.Parse("7715553b-fe8b-4a7e-88a3-36a1d023dc8b"), MovePGN = "e6", Turn = 2 }
                    }
                },
                Name = "Nakamaru vs el mikati",
                BugMessage = "",
                IsBugged = false,
                DateAdded = DateTime.Now.Date,
                Outcome = "Loss",
                PlayedAs = "Black",
                Moves = new List<GameMove>
                {
                    new GameMove { Id = Guid.Parse("92b82169-9538-4b19-a495-a3a0afaa1322"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "e4", Turn = 1, Annotation = "e4 opening, wowie!" },
new GameMove { Id = Guid.Parse("fc115905-54b5-4d87-9118-ceeb682647bb"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "e6", Turn = 2 },
new GameMove { Id = Guid.Parse("d861e933-044d-450d-a9e3-509e3bc570ed"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "d4", Turn = 3, Annotation = "Wowie, coole move!" },
new GameMove { Id = Guid.Parse("0fc5595d-547b-4e0f-a714-03a739ea74bd"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "d5", Turn = 4 },
new GameMove { Id = Guid.Parse("6118afd7-f758-48f9-8514-b96534d97f18"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nc3", Turn = 5 , Annotation = "Insane"},
new GameMove { Id = Guid.Parse("a0eb1ee7-1646-4b94-a966-9c971580819f"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nf6", Turn = 6 },
new GameMove { Id = Guid.Parse("4294d537-61d5-41c6-9640-d16c4254c375"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bg5", Turn = 7 },
new GameMove { Id = Guid.Parse("5135f6b2-ff81-46ec-aae3-cc1a708ed521"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "dxe4", Turn = 8 },
new GameMove { Id = Guid.Parse("162d2ad8-023e-4202-8959-0d373ad55b74"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nxe4", Turn = 9 },
new GameMove { Id = Guid.Parse("84fae53d-cd24-41d7-b03b-756fb6864272"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Be7", Turn = 10 },
new GameMove { Id = Guid.Parse("e5dbbc30-14db-400f-8620-63a7cdf0a2ae"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bxf6", Turn = 11 },
new GameMove { Id = Guid.Parse("8d51ef9d-9de9-48d9-a701-9305cd33000d"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bxf6", Turn = 12 },
new GameMove { Id = Guid.Parse("00d20a9c-6a58-4d0f-af58-9b96232af887"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "c3", Turn = 13 },
new GameMove { Id = Guid.Parse("96d1c58d-e75b-42b4-b526-8947759dea45"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nc6", Turn = 14 },
new GameMove { Id = Guid.Parse("4ac3ab76-d9ff-4f0e-b434-eb1b1ae741d3"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nf3", Turn = 15 },
new GameMove { Id = Guid.Parse("e35e2d01-a3da-448a-8ce0-bc24801e6a7d"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "e5", Turn = 16 },
new GameMove { Id = Guid.Parse("69741df7-b1a5-499c-8124-bfd9893eb318"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nxf6+", Turn = 17 },
new GameMove { Id = Guid.Parse("fd0a1c6b-db15-4b51-8142-62c19e24be5c"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qxf6", Turn = 18 },
new GameMove { Id = Guid.Parse("9d5475ac-9e40-451d-9c3d-02591240842a"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "dxe5", Turn = 19 },
new GameMove { Id = Guid.Parse("0c7af741-e43a-4148-b02e-91aee1f94e46"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nxe5", Turn = 20 },
new GameMove { Id = Guid.Parse("23bd902a-eea2-4316-96c6-a804c49b48db"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qe2", Turn = 21 },
new GameMove { Id = Guid.Parse("1e12b60a-25ae-4f2e-9ba5-028b89569623"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "O-O", Turn = 22 },
new GameMove { Id = Guid.Parse("cb43394b-eeaa-4ed7-844a-0850d7909bd7"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nxe5", Turn = 23 },
new GameMove { Id = Guid.Parse("11e474f7-e5e9-4a1a-b7b1-83bcc1831c82"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Re8", Turn = 24 },
new GameMove { Id = Guid.Parse("eaa9bc9a-6d16-4c2b-b67f-a4dfa5781ec5"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "O-O-O", Turn = 25 },
new GameMove { Id = Guid.Parse("98f04664-c137-457c-8b13-f99f1d3eebb3"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "h6", Turn = 26 },
new GameMove { Id = Guid.Parse("e217b8ab-b5b2-4275-89ec-6994d78495e8"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Re1", Turn = 27 },
new GameMove { Id = Guid.Parse("ae03bea1-9ace-4dc7-a124-065597d31098"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qf4+", Turn = 28 },
new GameMove { Id = Guid.Parse("c194b70b-b7b7-4ad5-99db-f5a3c35c489f"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qe3", Turn = 29 },
new GameMove { Id = Guid.Parse("101fbff6-d5c4-4878-b2c8-0dae5237de47"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qf5", Turn = 30 },
new GameMove { Id = Guid.Parse("48d63e44-2e18-4a3f-a46e-901aea4a03dc"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bd3", Turn = 31 },
new GameMove { Id = Guid.Parse("18e73f9a-0ee0-49a6-84fb-244f0a5aa259"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qe6", Turn = 32 },
new GameMove { Id = Guid.Parse("b36b66b0-7ded-4ebe-b995-dbf5c6331e67"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bc4", Turn = 33 },
new GameMove { Id = Guid.Parse("429a00b1-4243-412a-8074-0c01a6505be3"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qf5", Turn = 34 },
new GameMove { Id = Guid.Parse("24309917-cbf4-44b6-8be2-6e459bb9d2a9"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bxf7+", Turn = 35 },
new GameMove { Id = Guid.Parse("ab53d0d1-0e26-4afd-be7d-5546b1087c74"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kf8", Turn = 36 },
new GameMove { Id = Guid.Parse("aeecd81d-b900-4b3d-8ab8-6d1569eb9efd"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Ng6+", Turn = 37 },
new GameMove { Id = Guid.Parse("cedb7391-ccd2-4ab5-ac63-f249362390c3"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kxf7", Turn = 38 },
new GameMove { Id = Guid.Parse("a3ebd85f-4d46-47d1-ade8-64cef7204343"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qxe8+", Turn = 39 },
new GameMove { Id = Guid.Parse("e31e6d7b-314a-4bab-991b-a13c056cc8a9"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kf6", Turn = 40 },
new GameMove { Id = Guid.Parse("3f4dd780-cda0-4acb-9443-e372f270cded"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Re5", Turn = 41 },
new GameMove { Id = Guid.Parse("b4728019-a6ba-476e-b2ab-3022b3483f36"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qxe5", Turn = 42 },
new GameMove { Id = Guid.Parse("eea8c754-a4fd-4320-9a55-f9ae9feae430"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Nxe5", Turn = 43 },
new GameMove { Id = Guid.Parse("e89cf830-ba50-4596-a5f8-974bfae88600"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "b6", Turn = 44 },
new GameMove { Id = Guid.Parse("8b54bdcd-f410-44a9-8f02-97cf01d9dda7"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qc6+", Turn = 45 },
new GameMove { Id = Guid.Parse("d77f0511-f518-412f-93b0-05b1c026089c"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kxe5", Turn = 46 },
new GameMove { Id = Guid.Parse("8b9289ec-4f0a-4bee-901c-fa2f5ac7af67"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Re1+", Turn = 47 },
new GameMove { Id = Guid.Parse("16ae978d-759e-4704-bc9c-ff268205a09e"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kf4", Turn = 48 },
new GameMove { Id = Guid.Parse("797df46b-1d9b-40e2-8b40-e6a7ecf3f201"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "g3+", Turn = 49 },
new GameMove { Id = Guid.Parse("50e25e1d-2c58-4b3a-8ed6-b83a85c44577"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kg4", Turn = 50 },
new GameMove { Id = Guid.Parse("8a520260-da26-4d8e-95bf-72a7bf8690a2"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Re4+", Turn = 51 },
new GameMove { Id = Guid.Parse("52010575-1be3-4a98-93fa-6ba0c1901f3b"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kf3", Turn = 52 },
new GameMove { Id = Guid.Parse("91c2cdc0-62e8-4162-b338-07f90c3213e3"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Rf4+", Turn = 53 },
new GameMove { Id = Guid.Parse("8c635a2a-d542-4c94-bd2f-f7dd6301068f"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Ke2", Turn = 54 },
new GameMove { Id = Guid.Parse("b3eb38b2-d021-46ba-ba2d-e3ee353525e8"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qf3+", Turn = 55 },
new GameMove { Id = Guid.Parse("54978d67-ae01-4662-ac67-e247f302782f"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kf1", Turn = 56 },
new GameMove { Id = Guid.Parse("bf1aec46-8655-43a8-a4af-74ffc89e5726"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Re4", Turn = 57 },
new GameMove { Id = Guid.Parse("cd752eb0-d8c7-439d-9bba-ab28a9bcdfb1"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Bb7", Turn = 58 },
new GameMove { Id = Guid.Parse("833d835a-185c-4958-8b1c-d7b654330274"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qh1+", Turn = 59 },
new GameMove { Id = Guid.Parse("16cff63a-d4a3-4c3a-8510-31e0178fb69b"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Kxf2", Turn = 60 },
new GameMove { Id = Guid.Parse("8e47eab6-3aa9-4d42-9e44-02dec9c83a47"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Rf4+", Turn = 61 },
new GameMove { Id = Guid.Parse("854f1c6f-5fe3-484b-b1a4-889376e7a59e"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Ke2", Turn = 62 },
new GameMove { Id = Guid.Parse("fa572f86-a740-4fec-ab0d-b5f337c1d039"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qd1+", Turn = 63 },
new GameMove { Id = Guid.Parse("21d4f2f9-e0f2-4ffb-82a1-50a70abee818"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Ke3", Turn = 64 },
new GameMove { Id = Guid.Parse("c2b782ab-10df-4f15-b198-a0e9d84e01ac"), GameId = Guid.Parse("e0b65099-4d7e-4b98-9312-a16f229ca339"), MovePGN = "Qd2+", Turn = 65 }
                }
            }

        
        };


        public async Task<Game> GetGame(Guid id)
        {
            var game = gameList.FirstOrDefault(e => e.Id == id);
            return await Task.FromResult(game);
        }

        public async Task<IQueryable<Game>> GetGameListsForUser(Guid userid)
        {

            var games = gameList.Where(e => e.UserId == userid).AsQueryable();
            return await Task.FromResult(games);
        }

        public async Task<Game> AddGame(Game game)
        {

            gameList.Add(game);
            return await Task.FromResult(game);
        }

        public async Task<Game> UpdateGame(Game game)
        {

            var oldGame = gameList.FirstOrDefault(e => e.Id == game.Id);
            gameList.Remove(oldGame);
            gameList.Add(game);
            return await Task.FromResult(game);
        }

        public async Task<Game> DeleteGame(Guid id)
        {
            var oldGame = gameList.FirstOrDefault(e => e.Id == id);
            gameList.Remove(oldGame);
            return await Task.FromResult(oldGame);
        }

        public Task<IEnumerable<GameMove>> UpdateGameMoves(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
