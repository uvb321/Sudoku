using NUnit.Framework;
using SudokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTests
{
   
    namespace SudokuTests
    {
        /// <summary>
        /// this module is the testing module of the program, it consists 38 test of different boards, reading from files,
        /// handling exceptions and more
        /// </summary>
        public class SudokuBoardsTests
        {
            //1
            [Test]
            public void EmptyBoard1X1()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("0");
                Assert.That(solvedSudoku, Is.EqualTo("1"));
            }

            //2
            [Test]
            public void EmptyBoard4X4()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("0000000000000000");
                Assert.That(solvedSudoku, Is.EqualTo("1234341221434321"));
            }

            //3
            [Test]
            public void EmptyBoard9X9()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000000000000000000000000000000000000000000000000000000000000000000000000000000000");
                Assert.That(solvedSudoku, Is.EqualTo("123456789789123456456789123312845967697312845845697312231574698968231574574968231"));
            }


            //4
            [Test]
            public void EmptyBoard16X16()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
                Assert.That(solvedSudoku, Is.EqualTo("123456789:;<=>?@9:;<1234=>?@56785678=>?@12349:;<=>?@9:;<5678123431427586;9>:?<@=;9>:3142?<@=75867586?<@=3142;9>:?<@=;9>:7586314224136857:?9;<@=>:?9;2413<@=>68576857<@=>2413:?9;<@=>:?9;6857241343218765>;:9@=<?>;:94321@=<?87658765@=<?4321>;:9@=<?>;:987654321"));
            }


            //5
            [Test]
            public void EmptyBoard25X25()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
                Assert.That(solvedSudoku, Is.EqualTo("123456789:;<=>?@ABCDEFGHI;<=>?12345@ABCDFGEHI6789:6789:HIFEG12345;<=>?@ABCDGFEIH@ABCD6789:12345;<=>?@ABCD;<=>?HEGFI6789:123453152>C@D7;B?EHG8:IF<49A=648:6B31GH2=FI<>9@C;A5?DE7H?I7<459=631@A2BD>EG8:F;C9C;DE8FIA>45:7631?=2BH@<G=GAF@:?EB<89D;C45H7631>I2251?3>=AI8G@C:B<H;D974E6F7@6;42B153<HA8F>EG:=DIC?9<IGE8746;92D153A?FBC>=H:@>DCH9FG:@E746?=2I153<8;ABA:FB=<H?DC>I;E97468@2G153C6412IE;<HDB9G8?>@AF:573=5=937A8214FCHI;:BDGE?6<@>?BDGA5673@:>214C=9<HFEI8;F><@;B:C?=5673EI8214AD9GH:EH8ID9>GF?=<@A5673;CB214B3251?D48IA:F=HG;<@>9C67EI47=693@21CG>D<EF:?8H;5BAD;?<CG>567E3421H9AIB=@:F889@AFECH:BI;567=3421G>?D<EH>:G=;<FA98?B@DC567I3421"));
            }

            //6
            [Test]
            public void Solved1X1()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("1");
                Assert.That(solvedSudoku, Is.EqualTo("1"));
            }

            //7
            [Test]
            public void Solved4X4()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("1243432134122134");
                Assert.That(solvedSudoku, Is.EqualTo("1243432134122134"));
            }

            //8
            [Test]
            public void Solved9X9()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("123456789789123456456789123312845967697312845845697312231574698968231574574968231");
                Assert.That(solvedSudoku, Is.EqualTo("123456789789123456456789123312845967697312845845697312231574698968231574574968231"));
            }

            //9
            [Test]
            public void Solved16X16()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("123456789:;<=>?@9:;<1234=>?@56785678=>?@12349:;<=>?@9:;<5678123431427586;9>:?<@=;9>:3142?<@=75867586?<@=3142;9>:?<@=;9>:7586314224136857:?9;<@=>:?9;2413<@=>68576857<@=>2413:?9;<@=>:?9;6857241343218765>;:9@=<?>;:94321@=<?87658765@=<?4321>;:9@=<?>;:987654321");
                Assert.That(solvedSudoku, Is.EqualTo("123456789:;<=>?@9:;<1234=>?@56785678=>?@12349:;<=>?@9:;<5678123431427586;9>:?<@=;9>:3142?<@=75867586?<@=3142;9>:?<@=;9>:7586314224136857:?9;<@=>:?9;2413<@=>68576857<@=>2413:?9;<@=>:?9;6857241343218765>;:9@=<?>;:94321@=<?87658765@=<?4321>;:9@=<?>;:987654321"));
            }

            //10
            [Test]
            public void Solved25X25()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("123456789:;<=>?@ABCDEFGHI;<=>?12345@ABCDFGEHI6789:6789:HIFEG12345;<=>?@ABCDGFEIH@ABCD6789:12345;<=>?@ABCD;<=>?HEGFI6789:123453152>C@D7;B?EHG8:IF<49A=648:6B31GH2=FI<>9@C;A5?DE7H?I7<459=631@A2BD>EG8:F;C9C;DE8FIA>45:7631?=2BH@<G=GAF@:?EB<89D;C45H7631>I2251?3>=AI8G@C:B<H;D974E6F7@6;42B153<HA8F>EG:=DIC?9<IGE8746;92D153A?FBC>=H:@>DCH9FG:@E746?=2I153<8;ABA:FB=<H?DC>I;E97468@2G153C6412IE;<HDB9G8?>@AF:573=5=937A8214FCHI;:BDGE?6<@>?BDGA5673@:>214C=9<HFEI8;F><@;B:C?=5673EI8214AD9GH:EH8ID9>GF?=<@A5673;CB214B3251?D48IA:F=HG;<@>9C67EI47=693@21CG>D<EF:?8H;5BAD;?<CG>567E3421H9AIB=@:F889@AFECH:BI;567=3421G>?D<EH>:G=;<FA98?B@DC567I3421");
                Assert.That(solvedSudoku, Is.EqualTo("123456789:;<=>?@ABCDEFGHI;<=>?12345@ABCDFGEHI6789:6789:HIFEG12345;<=>?@ABCDGFEIH@ABCD6789:12345;<=>?@ABCD;<=>?HEGFI6789:123453152>C@D7;B?EHG8:IF<49A=648:6B31GH2=FI<>9@C;A5?DE7H?I7<459=631@A2BD>EG8:F;C9C;DE8FIA>45:7631?=2BH@<G=GAF@:?EB<89D;C45H7631>I2251?3>=AI8G@C:B<H;D974E6F7@6;42B153<HA8F>EG:=DIC?9<IGE8746;92D153A?FBC>=H:@>DCH9FG:@E746?=2I153<8;ABA:FB=<H?DC>I;E97468@2G153C6412IE;<HDB9G8?>@AF:573=5=937A8214FCHI;:BDGE?6<@>?BDGA5673@:>214C=9<HFEI8;F><@;B:C?=5673EI8214AD9GH:EH8ID9>GF?=<@A5673;CB214B3251?D48IA:F=HG;<@>9C67EI47=693@21CG>D<EF:?8H;5BAD;?<CG>567E3421H9AIB=@:F889@AFECH:BI;567=3421G>?D<EH>:G=;<FA98?B@DC567I3421"));
            }


            //11
            [Test]
            public void Board9X9_1()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000000010400000000020000000000050407008000300001090000300400200050100000000806000");
                Assert.That(solvedSudoku, Is.EqualTo("693784512487512936125963874932651487568247391741398625319475268856129743274836159"));
            }

            //12
            [Test]
            public void Board9X9_2()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000700006900000100080000000000042007000008000608030005000000000006000048000090000");
                Assert.That(solvedSudoku, Is.EqualTo("234715986965824173187369524359642817471958632628137495713486259596271348842593761"));
            }

            //13
            [Test]
            public void Board4X4_1()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("0001000200030004");
                Assert.That(solvedSudoku, Is.EqualTo("2431134241233214"));
            }

            //14
            [Test]
            public void Board4X4_2()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("1000020000300004");
                Assert.That(solvedSudoku, Is.EqualTo("1342421324313124"));
            }

            //15
            [Test]
            public void Board16X16_1()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000000000000000000000000000000000000000000000007000000000000000000000000001000000000000000000000000000>000000003000000000000000000000000000000000000200000000000000000000000000000000000000000000000000<000000000000000:0000000000000000000009000000000000000000");
                Assert.That(solvedSudoku, Is.EqualTo("?<@9:127658=43>;7;=8<9431@>?2:65214:>568;39<=?@7536>;=?@724:819<<@9537:2?;1>648=;=7318<4:6@29>5?12:45?>69<=87@;38?>6=@9;47351<:265?;7:318=<9@24>=>172<89@45;?63::83@4>=521?6;7<9492<6;@?>:735=18@48=921<5>:73;?696<1837:=?;@>52437;2?45><861:9=@>:5?@6;=3924<871"));
            }

            //16
            [Test]
            public void Board16X16_2()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("<000000000400000000000000001000000000:000000000000000000000000000000000005000000000?00000200000000000000000000000000000000000000060078900000000000000000000000000000000050000000000000000000:000000000000000000000000000000000000000000000000000000000000000000>");
                Assert.That(solvedSudoku, Is.EqualTo("<19=26837:45;@>?3:6>@;7?8<=12495745;>:=9@?321<682@?8145<>96;3:=78;129=:745<36>?@>5:?<36@=217894;67=98>42?;:@<513@<43?51;9>8672:=56;1789:<32=>?@4?8><6@31:4;95=72:374=?2>51@89;<69=2@5<;467?>:3811>@:37<82=54?6;9=987;2?63@>:415<;?3549>=167<@82:42<6:1@5;89?=73>"));
            }

            //17
            [Test]
            public void Board25X25_1()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000000000000000000000000000000000000000000000000000000000000000000000090000000000000000000000500000000000000000000000000000000000000000000000000100000000000:000000>00000000000000000000000000000000000000000000000000000000000000020000000000000000000000000000000000000000200000000<>0000000000000000000000000000000000000080000000000000000000000000000000000000000?0000=0000000000000000000000000003000000000000000000000000000000000000000000000000000000000000000000000040000000000000000000000000000000000000005000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000090<0000000000");
                Assert.That(solvedSudoku, Is.EqualTo("68>27;@1=A3B<5C9DE:FGH4I?B<45:C?3E2DF>9H6@AIG71=;8;3@1A>BDFH6I24G=87C?9E<5:9DEH?78<GI=;:@A>14526BC3FC=FGI956:4?817E3<;BH>@AD2>:78=DECA694F<325B;1HI@?G51?C<2:49=EDG>8AHIF@;637B@6;AB?F>382CHI57EDG<:914=IGHED1;5@B:=7?649>382AFC<4923FI7H<G1@AB;:=C?6ED>85DEGF6B1IH789?3><452=@:;ACAI<>HF6G;94251@?:37C8=DBE=@9;3<>25CA:EHB1G86D4?7FI?B:7C84=DE<6;GFI>@A9125H325841@A:?3C7D=IB;FHE<>G698>=?24HEC;@<6A9F3:15B7IGDH;A@5GIF7D>?3218B=E4C<9:6<4369A2B>5FGC;:DIH@7?8E=1:7CBE3<981IH4D=G?6>;F52@A1FDIG:=?6@B58E7C2<9A3;H>4FC59>=G81<73@:2HA?DBI46E;7A1=8EC@I:;>B645F9<3DG?2HG?6<4H3;2>5AICDE718:=FB9@EHID;69ABFG1=8?@C24>53:<732B:@5D74?HE9F<;6G=IAC81>"));
            }

            //18
            [Test]
            public void Board25X25_2()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("100000000000000000000000000000000000?0000000000003000000040000000000009000000000000000000000050000000000000>000000000000000000000:00000000000000100000000000:000000>000000000000=000000000000;000000000000000000000000000000000000020000000000000000000000000000000000000000200000000<>00000000000000000000:0000000000000000080000000000000000000000000000000000000000?0000=0000000000000000000000000003000000000000000000000000000000000000000000000000000000000700000000000040000000000000000300000000000000000000005000000000000000000000000000000000000000000000080000000000000000000000000000000000000008000000000000000000000090<0000000000");
                Assert.That(solvedSudoku, Is.EqualTo("1>658@?AB<43;9=CDE:F7G2HIDHI2F59=6E>?8G:17@AB4;C<33BC=?1;4HID27FE>6G8<95@:A@A7EGF3:82<BCIH94;5=>16?D9:4<;CD>7G516@A3I2?HBE8=F>38@:GI;<C27A4965DF1?BHE=5D1AB?:6=8@IF>3GCH;E2<749I=?7H>1254GDE8;<@9B3:CAF6E4GF<ABHD9:C=612>?78I3;5@;926CE73@FB5H<?:A4=ID>G816GAI7D81;59<>?4=:32@HFBCE42<>9ICGEB8F3;@?15H7=AD6:=FDH@:><376GB5CAE8I912?;4?;BCE=H@F61:2A74<>GD8I395:8315429?AEHD=I;BFC6<7>@G75>8=B@E4;H9?C2F3A1:G6ID<AIHG176C9?=;@:>D8<E534F2BFCEB62=5>:3A<DG@HI4?;8917<?:9D3F8G1IE4B672C>;@=5AH2@;43H<IAD7851FB9=6GC:E>?H653>9E71@?4G2B8;:<AFD=ICG7=DA64FCH;>:35I?1@2E9<B88<9?4;AB:>F6IEDH=73C5@1G2BE@:2<GDI3C=1H85F69>A?47;C1F;I85?2=A@97<EGBD46H:3>"));
            }

            //19
            [Test]
            public void IllegalSizeTest_1()
            {
                Assert.Throws<InvalidBoardSizeException>(() => Utils.ValidateAndSolveBoard(""));
            }

            //20
            [Test]
            public void IllegalSizeTest_2()
            {
                Assert.Throws<InvalidBoardSizeException>(() => Utils.ValidateAndSolveBoard("038459080849434"));
            }

            //21
            [Test]
            public void InvalidInputTest_1()
            {
                Assert.Throws<InvalidCharException>(() => Utils.ValidateAndSolveBoard("erfojerfgfghjkop"));
            }

            //22
            [Test]
            public void InvalidInputTest_2()
            {
                Assert.Throws<InvalidCharException>(() => Utils.ValidateAndSolveBoard("0000000000000050"));
            }

            //23
            [Test]
            public void InvalidBoardTest_1()
            {
                //checking rows
                Assert.Throws<InvalidBoardException>(() => Utils.ValidateAndSolveBoard("1100000000000000"));
            }

            //24
            [Test]
            public void InvalidBoardTest_2()
            {
                //checking columns
                Assert.Throws<InvalidBoardException>(() => Utils.ValidateAndSolveBoard("4000000000004000"));
            }

            //25
            [Test]
            public void InvalidBoardTest_3()
            {
                //checking boxes
                Assert.Throws<InvalidBoardException>(() => Utils.ValidateAndSolveBoard("2000020000004000"));
            }

            //26
            [Test]
            public void Board9X9_3()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000000300000000000900000000000010000000050000067800000000000000000400000300000002");
                Assert.That(solvedSudoku, Is.EqualTo("514297368632581947978346125253614789189752436467839251725963814891425673346178592"));
            }

            //27
            [Test]
            public void Board16X16_3()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("0000000000>00000005000000000000000900<000000800000000010000000000?0000000000000200000000:00000000;0000050000000600000000?0000000500000000:00000030000000>0000000000=004000000500000000070000300000000;0000000:000000000<0000000000090000000010000000000060000200");
                Assert.That(solvedSudoku, Is.EqualTo("821745?9<@>;:63=<>5;@836=1:924?74396=<:;7?528@>1=:?@>7128463<95;9?:5<67318=>4;@278=3;42@:596?<1>@;>1?:952<3478=664<21>8=?7;@53:959;>8@<13:476=2?378<52;?>6@=914::1@=634>92?<;578?624:9=75;183><@254?3;68@=71>:9<1@689?5<4>2:=7;3><792=@:;3851?64;=3:71>469<?@285"));
            }

            //28
            [Test]
            public void Board25X25_3()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000003000000500000000000000000@000000000800000000000600000000000000000000000000000000A10000000000000>00000000C0000000000000000000000000<00000000000000000000002000000000000000000000:0000000;0000000000@0000000000000000000000000000000B000000000000000000000000:000000000400030000000000000000000000000000700000000?000040000000000000000000000800000000060000000010000000000000?00000000000000000007000000000000E00000000000D0000000000F0000000000030000000000000<00000000>00000000000000000000000000000000000000000000000000000000000000000000000?00000000000000000020000000000000000008000000000000000000000090000000006000000000300000000004");
                Assert.That(solvedSudoku, Is.EqualTo("8;<2B37A1:E>564CIDF9@=GH?=A95F@>G;43DHIB8?2671C:<EE36DH?5=I<C:;GF>1B4@7829AG?C7I869HBA12@<=3:5E>;D4F>14@:2EFDC8?79=G;AH<B3I65DHAC6F?@89<=173;E4>:G25IB1B3:5G;C2H4E>D6F@I7=A<?89278>4:<36I9HA;?BCG15EF=D@@IG?E5D17=F2:B89<3A6;4>CH<9;F=AB4>EI@GC5D2?8H:73166FI<CB:7=25;D1AH49E83?@G>H5:8DCI<9>?36=21G@B;4EAF7;E>G9638?@HCF4:7A5I2D1B=<?@B1A4FD5;78IEG3=<C>H69:2347=21HEAG@B<>96DF:?CI85;A62I3>1:@?=<487E5HDGF9;BC5CE48H92361GB?DAF;=I<>7@:FD@91;=BC8:A35E<>7246GH?I:<=;?7GIED>6CFH@983B5A4217>HBG<A54F;I92@:61?C=DE384=DH<926:3B58A>?7C;1I@FEGC85A>E4?<7GF=HI2B6@39:1;D92FE;D@>B164?:CIH=GA85<73B:?3@IC;G5D7E<148>9F2H6A=IG167=8HFA29@3;5:E<D?BC>4"));
            }

            //29
            [Test]
            public void ReadFromFile_1_FNF()
            {
                Assert.Throws<FileException>(() => FileHandler.ReadFile("fsfsf"));
            }

            //30
            [Test]
            public void ReadFromFile_2_ReadAndSolve4X4()
            {
                string Sudoku = FileHandler.ReadFile("sudoku_test_1.txt");
                string SolvedSudoku = Utils.ValidateAndSolveBoard(Sudoku);
                Assert.That(SolvedSudoku, Is.EqualTo("1234341221434321"));

            }

            //31
            [Test]
            public void ReadFromFile_3_ReadAndSolve9X9()
            {
                string Sudoku = FileHandler.ReadFile("sudoku_test_2.txt");
                string SolvedSudoku = Utils.ValidateAndSolveBoard(Sudoku);
                Assert.That(SolvedSudoku, Is.EqualTo("751486932683925174294317568428571396976843215135692487549168723362759841817234659"));
            }

            //32
            [Test]
            public void ReadFromFile_4_ReadAndSolve1X1()
            {
                string Sudoku = FileHandler.ReadFile("sudoku_test_3.txt");
                string SolvedSudoku = Utils.ValidateAndSolveBoard(Sudoku);
                Assert.That(SolvedSudoku, Is.EqualTo("1"));
            }

            //33
            [Test]
            public void ReadFromFile_5_ReadAndSolve16X16()
            {
                string Sudoku = FileHandler.ReadFile("sudoku_test_4.txt");
                string SolvedSudoku = Utils.ValidateAndSolveBoard(Sudoku);
                Assert.That(SolvedSudoku, Is.EqualTo("9@1<;?4536=>287::?;>1<=@7842653983572:>6;?@9<=412=6487391<5:@>?;129@?=5;<>:43687<;8539@72=?641:>4:>?<861@73;=952673=4>:28195?;@<3>21:48=9@6<7?;559?;7@2>4381:<=67<4651;3?:2=9@>8@8=:96?<5;>71423?673=598>2<@;:14;4<8@37:651?>29==1@2>;<4:978536?>5:9621?=4;387<@"));
            }

            //34
            [Test]
            public void ReadFromFile_6_ReadAndSolve25X25()
            {
                string Sudoku = FileHandler.ReadFile("sudoku_test_5.txt");
                string SolvedSudoku = Utils.ValidateAndSolveBoard(Sudoku);
                Assert.That(SolvedSudoku, Is.EqualTo("425;7DBE?1AI<=6>9G3CHF@:8:@93GHCA=6?1BF4E82ID<7;5>A8=HD<59I3;@E7>:F?B4G2C166>?1I:2FG@8HDC3;7<5AB4E9=<EBFC;8>74:9G52@6=1HD3IA?53:82=G6AE<D1I?B;C9@4H>7F;7DI<1439B>ECGF=HA2568:?@=46BF?<;:IH5@893D7>ECG12AH?@A1>F7DC3;42=8G:6IE<5B9>GCE98@25H76:BA<?4F1I=3D;E:863G1CB;F?IAD95@<72>4=HCIF<;6=DH2@4>1B?3E:G59A877DH2593@4>G86E;1AI=F?B<C:194G>A?IEF=<7:5HCB82@D6;3?=A@B7:8<5239HC4>6D;1EFGIBCI9?F;41=6GA@:7<DE385H>28F<D=BEGCAI2;315:>H?9@76436G4E57:2DC>H9<I18@=A;?FB@1;>AI6H894=5?7C2FGB3:DE<257:H@>?3<BF8DE64;A9=1GICIH3=8EA1;:D7?>@GB9C<F6245G;EC43D=6?9B2<IF@57:>A8H1DB1562I<>7ECF;HA=348:?9@G9A2?@4HBF85:36GDI1;>7C=<EF<>7:C95@G1A=482EH?6;IB3D"));
            }

            //35
            [Test]
            public void Unsolveable4X4()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("1034" +
                    "0200" +
                    "0300" +
                    "0400");
                Assert.That(solvedSudoku, Is.EqualTo(""));
            }

            //36
            [Test]
            public void Unsolveable9X9()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("516849732307605000809700065135060907472591006968370050253186074684207500791050608");
                Assert.That(solvedSudoku, Is.EqualTo(""));
            }

            //37
            [Test]
            public void Unsolveable16X16()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("100000000000000020000000000000003000000000000000400000000000000050000000000000006000000000000000700000000000000000000000000000089000000000000000:000000000000000;000000000000000<0000000000000000>000000000000000=000000000000000@000000000000000?00000000000000");
                Assert.That(solvedSudoku, Is.EqualTo(""));
            }

            //38
            [Test]
            public void Unsolveable25X25()
            {
                string solvedSudoku = Utils.ValidateAndSolveBoard("000000000000000000000000100000000000000000000000020000000000000000000000003000000000000000000000000400000000000000000000000050000000000060000000000000000000000000000000000000700000000000000000000000080000000000000000000000009000000000000000000000000:000000000000000000000000;000000000000000000000000<000000000000000000000000=000000000000000000000000>000000000000000000000000000000000000000000000000@000000000000000000000000A000000000000000000000000B000000000000000000000000C000000000000000000000000D000000000000000000000000E0000000000000000000000000F000000000000000000000000G0000000000000000000000000H00000000000000000000000I");
                Assert.That(solvedSudoku, Is.EqualTo(""));
            }

           


        }
    }
}

