using CSVExample;

class Program
{
    static void Main()
    {
        #region DataCSV

        // Generate 100 Fake Data CSV format in Mockaroo.com
        File.WriteAllText(Shared.FilePath, "1,Lloyd,Crockatt,lcrockatt0@theatlantic.com,Male\r\n2,Mason,Murdoch,mmurdoch1@twitpic.com,Male\r\n3,Archambault,Briar,abriar2@yellowbook.com,Male\r\n4,Allen,Ffoulkes,affoulkes3@4shared.com,Male\r\n5,Frans,Cristofanini,fcristofanini4@china.com.cn,Male\r\n6,Kliment,Reddings,kreddings5@cocolog-nifty.com,Male\r\n7,Yulma,Skittreal,yskittreal6@apple.com,Male\r\n8,Myriam,Redley,mredley7@gizmodo.com,Female\r\n9,Joanie,Ghiraldi,jghiraldi8@tuttocitta.it,Female\r\n10,Tallie,Malone,tmalone9@stumbleupon.com,Male\r\n11,Robin,Lafaye,rlafayea@pbs.org,Male\r\n12,Christoffer,Benito,cbenitob@zdnet.com,Male\r\n13,Gaile,Brodley,gbrodleyc@nasa.gov,Male\r\n14,Marysa,McPake,mmcpaked@friendfeed.com,Female\r\n15,Tomi,Bleue,tbleuee@who.int,Polygender\r\n16,Mar,Bolley,mbolleyf@dot.gov,Genderfluid\r\n17,Noreen,Hiscocks,nhiscocksg@vk.com,Female\r\n18,Archer,Cavozzi,acavozzih@hud.gov,Male\r\n19,Tricia,Bolton,tboltoni@so-net.ne.jp,Female\r\n20,Rhodie,Cadman,rcadmanj@hhs.gov,Female\r\n21,Bax,Quinevan,bquinevank@sciencedaily.com,Male\r\n22,Lola,Camocke,lcamockel@fotki.com,Agender\r\n23,Jermain,Naile,jnailem@nhs.uk,Male\r\n24,Haroun,Blackbourn,hblackbournn@nytimes.com,Male\r\n25,Georgi,Meysham,gmeyshamo@salon.com,Male\r\n26,Lowell,Tunsley,ltunsleyp@bloglovin.com,Male\r\n27,Jillayne,Seebright,jseebrightq@purevolume.com,Agender\r\n28,Nat,De Cruz,ndecruzr@typepad.com,Genderqueer\r\n29,Arlan,Endley,aendleys@vistaprint.com,Male\r\n30,Nydia,Bertelet,nbertelett@timesonline.co.uk,Female\r\n31,Beatrice,Gipps,bgippsu@edublogs.org,Female\r\n32,Guss,Garbert,ggarbertv@nih.gov,Male\r\n33,Gui,Gerdes,ggerdesw@ibm.com,Female\r\n34,Lewiss,Lincke,llinckex@discuz.net,Male\r\n35,Elnora,Trimmill,etrimmilly@i2i.jp,Female\r\n36,Ortensia,Byneth,obynethz@ihg.com,Female\r\n37,Waverly,Pine,wpine10@squidoo.com,Male\r\n38,Calida,Kaliszewski,ckaliszewski11@wisc.edu,Female\r\n39,Haleigh,Lafontaine,hlafontaine12@sina.com.cn,Male\r\n40,Durward,McPeck,dmcpeck13@icq.com,Male\r\n41,Edithe,Dewhurst,edewhurst14@walmart.com,Female\r\n42,Rozanna,McAreavey,rmcareavey15@wisc.edu,Female\r\n43,Chloris,Milella,cmilella16@bloomberg.com,Female\r\n44,Paul,Vigors,pvigors17@flickr.com,Male\r\n45,Derrek,Parade,dparade18@opera.com,Male\r\n46,Vasily,Escoffrey,vescoffrey19@ustream.tv,Male\r\n47,Worden,Josefer,wjosefer1a@woothemes.com,Agender\r\n48,Archibold,Sclanders,asclanders1b@alexa.com,Male\r\n49,Gregg,Lang,glang1c@istockphoto.com,Male\r\n50,Malva,Evenden,mevenden1d@vkontakte.ru,Female\r\n51,Raff,Ellice,rellice1e@miibeian.gov.cn,Male\r\n52,Peyton,Obee,pobee1f@etsy.com,Male\r\n53,Dorella,Scanlin,dscanlin1g@acquirethisname.com,Female\r\n54,Jillane,Kundt,jkundt1h@latimes.com,Female\r\n55,Gardener,Hought,ghought1i@yellowpages.com,Male\r\n56,Eloisa,Hutley,ehutley1j@sakura.ne.jp,Female\r\n57,Tallie,Crippes,tcrippes1k@illinois.edu,Male\r\n58,Natalya,Tremethack,ntremethack1l@ihg.com,Genderqueer\r\n59,Mikol,Avory,mavory1m@skype.com,Male\r\n60,Cory,De Mars,cdemars1n@wired.com,Male\r\n61,Carolina,Simonyi,csimonyi1o@zimbio.com,Female\r\n62,Nevsa,McCurt,nmccurt1p@thetimes.co.uk,Female\r\n63,Lisa,Juschke,ljuschke1q@sun.com,Female\r\n64,Aristotle,Solon,asolon1r@si.edu,Male\r\n65,Herminia,Stockey,hstockey1s@edublogs.org,Polygender\r\n66,Janith,Keedy,jkeedy1t@nih.gov,Agender\r\n67,Alika,Balm,abalm1u@businessweek.com,Female\r\n68,Farlee,Treneman,ftreneman1v@imgur.com,Male\r\n69,Howey,Stockau,hstockau1w@china.com.cn,Male\r\n70,Karena,Coundley,kcoundley1x@zdnet.com,Female\r\n71,Davine,Caldecot,dcaldecot1y@cnbc.com,Polygender\r\n72,Zechariah,Raatz,zraatz1z@merriam-webster.com,Bigender\r\n73,De witt,Cottey,dcottey20@icio.us,Non-binary\r\n74,Francene,Ringham,fringham21@mapquest.com,Female\r\n75,Ingamar,McLaverty,imclaverty22@biblegateway.com,Male\r\n76,Hildagarde,Elecum,helecum23@nifty.com,Female\r\n77,Bent,Danielsohn,bdanielsohn24@icio.us,Male\r\n78,Babbie,Haveline,bhaveline25@phoca.cz,Female\r\n79,Lanie,Gault,lgault26@icq.com,Bigender\r\n80,Gerladina,Sherewood,gsherewood27@discuz.net,Female\r\n81,Malcolm,Egle,megle28@tinypic.com,Male\r\n82,Kennie,Boughen,kboughen29@goo.ne.jp,Non-binary\r\n83,Nestor,Peealess,npeealess2a@weather.com,Male\r\n84,Freddi,Goscomb,fgoscomb2b@mozilla.com,Female\r\n85,Quintin,Greenhall,qgreenhall2c@goodreads.com,Male\r\n86,Raine,D'Andrea,rdandrea2d@yandex.ru,Female\r\n87,Beulah,Reuther,breuther2e@gravatar.com,Female\r\n88,Rem,Louche,rlouche2f@hugedomains.com,Male\r\n89,Tore,Skegg,tskegg2g@ocn.ne.jp,Male\r\n90,Merell,Halley,mhalley2h@redcross.org,Male\r\n91,Vickie,Baynton,vbaynton2i@taobao.com,Female\r\n92,Wernher,Mussared,wmussared2j@so-net.ne.jp,Male\r\n93,Florence,Spellacey,fspellacey2k@themeforest.net,Female\r\n94,Barth,Johnston,bjohnston2l@vistaprint.com,Male\r\n95,Aidan,Ferrers,aferrers2m@bizjournals.com,Female\r\n96,Ange,Waslin,awaslin2n@dailymotion.com,Male\r\n97,Nichol,Ogle,nogle2o@4shared.com,Female\r\n98,Katey,Josilowski,kjosilowski2p@dailymotion.com,Female\r\n99,Peyton,Quye,pquye2q@netlog.com,Male\r\n100,Dedie,Fulcher,dfulcher2r@wikipedia.org,Female");

        #endregion DataCSV

        // Read data from the file. Assume that the file written by some other application
        // And we are going to read the same data here
        using (StreamReader sr = new(Shared.FilePath))
        {
            string? line;
            int lineNumber = 0;

            // Create a chunk (an empty list of string)
            List<string> chunks = new();

            // Create a collection of threads
            List<Thread> threads = new();
            int threadCount = 0;

            // Read each line from the file
            while ((line = sr.ReadLine()) != null)
            {
                // Skip the iteration if the line is null
                if (string.IsNullOrEmpty(line)) continue;

                // Format: id,first_name,last_name,email,gender

                // Line is not null, then increase the line count
                lineNumber++;

                chunks.Add(line);

                // If reach to end of chunk
                if (lineNumber % Shared.ChunkSize == 0)
                {
                    threadCount++;

                    // Create duplicate copy of chunk
                    List<string> chunkCopy = chunks.Select(item => item).ToList();

                    // Create chunk name
                    string chunkName = $"Chunk {threadCount}";

                    // Create thread object to handle chunk
                    Thread thread = new(() =>
                    {
                        InvokeDataProcessor(chunkName, chunkCopy);
                    });

                    // Add thread to thread collection
                    threads.Add(thread);
                    // Clear Chunks
                    chunks.Clear();
                }
            }

            // Main thread will wait until completion of child threads
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        Console.WriteLine("End of Main Thread");
        Console.ReadKey();
    }

    private static void InvokeDataProcessor(string chunkName, List<string> chunkCopy)
    {
        // Create an object of DataProcessor class
        DataProcessor dataProcessor = new()
        {
            ChunkName = chunkName,
            Chunk = chunkCopy,
        };

        // Invoke ProcessChunk method to perform actual process of data
        dataProcessor.ProcessChunk();

        // Print output
    }
}