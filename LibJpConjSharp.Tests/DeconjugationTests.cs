using System.Linq;
using LibJpConjSharp.Deconjugation;
using NUnit.Framework;

namespace LibJpConjSharp.Tests
{
    public class DeconjugationTests
    {
        [TestCase("言ってもいいですよ", "言う", WordType.TeForm, WordType.MoAfterTe, WordType.Ii, WordType.PoliteDesuVerb, WordType.YoParticle)]
        [TestCase("遊べそうじゃないね", "遊ぶ", WordType.Potential, WordType.MasuStem, WordType.Appearance, WordType.Da, WordType.NegativeNaiVerb, WordType.NeParticle)]
        [TestCase("誘ってもらわれてくれなかった", "誘う", WordType.TeForm, WordType.Morau, WordType.Passive, WordType.TeForm, WordType.Kureru, WordType.NegativeNaiVerb, WordType.PlainPast)]
        [TestCase("遊んでるべく", "遊ぶ", WordType.TeForm, WordType.ShortIru, WordType.Beku)]
        [TestCase("敷きやがりなさい", "敷く", WordType.MasuStem, WordType.Yagaru, WordType.MasuStem, WordType.Nasai)]
        [TestCase("重なり次第だ", "重なる", WordType.MasuStem, WordType.Shidai, WordType.Da)]
        [TestCase("生き過ぎだ", "生きる", WordType.MasuStem, WordType.Sugi, WordType.Da)]
        [TestCase("覚え難いの", "覚える", WordType.MasuStem, WordType.Gatai, WordType.ExplanatoryNoParticle)]
        [TestCase("覚えがたいよ", "覚える", WordType.MasuStem, WordType.Gatai, WordType.YoParticle)]
        [TestCase("飛びつつあった", "飛ぶ", WordType.MasuStem, WordType.TsutsuAru, WordType.PlainPast)]
        [TestCase("笑いたいのでありたい", "笑う", WordType.MasuStem, WordType.Tai, WordType.ExplanatoryNoParticle, WordType.Da, WordType.DeAru, WordType.MasuStem, WordType.Tai)]
        [TestCase("笑いたくなった", "笑う", WordType.MasuStem, WordType.Tai, WordType.Adverb, WordType.Naru, WordType.PlainPast)]
        [TestCase("笑うはずです", "笑う", WordType.Hazu, WordType.Da, WordType.PoliteDesuVerb)]
        [TestCase("笑わないようだろう", "笑う", WordType.NegativeNaiVerb, WordType.You, WordType.Da, WordType.Darou)]
        [TestCase("笑ったようね", "笑う", WordType.PlainPast, WordType.You, WordType.NeParticle)]
        [TestCase("来たばかりです", "来る", WordType.PlainPast, WordType.TaBakari, WordType.Da, WordType.PoliteDesuVerb)]
        [TestCase("死んじゃったりして", "死ぬ", WordType.TeForm, WordType.Shimau, WordType.Jau, WordType.Tari, WordType.TeForm)]
        [TestCase("死んじゃったら", "死ぬ", WordType.TeForm, WordType.Shimau, WordType.Jau, WordType.Tara)]
        [TestCase("叫んですみませんでした", "叫ぶ", WordType.TeForm, WordType.Sumanai, WordType.Sumimasen, WordType.PoliteMasenDeshita)]
        [TestCase("沈んでもかまわない", "沈む", WordType.TeForm, WordType.MoAfterTe, WordType.Kamau, WordType.NegativeNaiVerb)]
        [TestCase("沈んでいった", "沈む", WordType.TeForm, WordType.TeIku, WordType.PlainPast)]
        [TestCase("上がってくよ", "上がる", WordType.TeForm, WordType.TeIku, WordType.YoParticle)]
        [TestCase("話してこないだろう", "話す", WordType.TeForm, WordType.TeKuru, WordType.NegativeNaiVerb, WordType.Darou)]
        [TestCase("終わらせてからでしょうね", "終わる", WordType.Causative, WordType.TeForm, WordType.TeKara, WordType.Da, WordType.Darou, WordType.PoliteDeshou, WordType.NeParticle)]
        [TestCase("名乗って欲しかったな", "名乗る", WordType.TeForm, WordType.Hoshii, WordType.PlainPast, WordType.NaParticle)]
        [TestCase("試してみてね", "試す", WordType.TeForm, WordType.Miru, WordType.TeForm, WordType.NeParticle)]
        [TestCase("忘れちゃったね", "忘れる", WordType.TeForm, WordType.Shimau, WordType.Chau, WordType.PlainPast, WordType.NeParticle)]
        [TestCase("見てあげなさい", "見る", WordType.TeForm, WordType.Ageru, WordType.MasuStem, WordType.Nasai)]
        [TestCase("下がってくれよ", "下がる", WordType.TeForm, WordType.Kureru, WordType.Imperative, WordType.YoParticle)]
        [TestCase("笑わなくてはいけないよ", "笑う", WordType.NegativeNaiVerb, WordType.NakuteNakerebaIkenaiNaranai, WordType.YoParticle)]
        [TestCase("笑っては駄目なのよ", "笑う", WordType.TeForm, WordType.TeDame, WordType.Da, WordType.ExplanatoryNoParticle, WordType.YoParticle)]
        [TestCase("笑ってはいけないのだ", "笑う", WordType.TeForm, WordType.TeIkenaiNaranai, WordType.ExplanatoryNoParticle, WordType.Da)]
        [TestCase("笑ってはいけないんだ", "笑う", WordType.TeForm, WordType.TeIkenaiNaranai, WordType.ExplanatoryNoParticle, WordType.Da)]
        [TestCase("笑ってはいけないのだ", "笑う", WordType.TeForm, WordType.TeIkenaiNaranai, WordType.ExplanatoryNoParticle, WordType.Da)]
        [TestCase("笑わなくてはいけないよ", "笑う", WordType.NegativeNaiVerb, WordType.NakuteNakerebaIkenaiNaranai, WordType.YoParticle)]
        [TestCase("笑わされる", "笑う", WordType.Causative, WordType.ShortenedCausative, WordType.Passive)]
        [TestCase("逃げてもいい", "逃げる", WordType.TeForm, WordType.MoAfterTe, WordType.Ii)]
        [TestCase("食べなくてよいよ", "食べる", WordType.NegativeNaiVerb, WordType.TeForm, WordType.Ii, WordType.Ii, WordType.YoParticle)]
        [TestCase("食べなくていいよ", "食べる", WordType.NegativeNaiVerb, WordType.TeForm, WordType.Ii, WordType.YoParticle)]
        [TestCase("食べなくてはいいよ", "食べる", WordType.NegativeNaiVerb, WordType.TeForm, WordType.WaAfterTe, WordType.Ii, WordType.YoParticle)]
        [TestCase("食べに", "食べる", WordType.MasuStem, WordType.MasuStemNi)]
        [TestCase("逃げなよ", "逃げる", WordType.MasuStem, WordType.Nasai, WordType.YoParticle)]
        [TestCase("逃げるなよ", "逃げる", WordType.NaCommand, WordType.YoParticle)]
        [TestCase("逃げやすいですね", "逃げる", WordType.MasuStem, WordType.Yasui, WordType.PoliteDesuVerb, WordType.NeParticle)]
        [TestCase("逃げにくいですね", "逃げる", WordType.MasuStem, WordType.Nikui, WordType.PoliteDesuVerb, WordType.NeParticle)]
        [TestCase("逃げられすぎた", "逃げる", WordType.PotentialPassive, WordType.MasuStem, WordType.Sugiru, WordType.PlainPast)]
        [TestCase("逃げられ過ぎた", "逃げる", WordType.PotentialPassive, WordType.MasuStem, WordType.Sugiru, WordType.PlainPast)]
        [TestCase("逃げ方ですね", "逃げる", WordType.MasuStem, WordType.Kata, WordType.Da, WordType.PoliteDesuVerb, WordType.NeParticle)]
        [TestCase("逃げかたですね", "逃げる", WordType.MasuStem, WordType.Kata, WordType.Da, WordType.PoliteDesuVerb, WordType.NeParticle)]
        [TestCase("逃げがちですね", "逃げる", WordType.MasuStem, WordType.Gachi, WordType.Da, WordType.PoliteDesuVerb, WordType.NeParticle)]
        [TestCase("追われながら", "追う", WordType.Passive, WordType.MasuStem, WordType.Nagara)]
        [TestCase("出しはしないよ", "出す", WordType.MasuStem, WordType.MasuStemWaShinai, WordType.YoParticle)]
        [TestCase("行きたがっていますね", "行く", WordType.MasuStem, WordType.Tai, WordType.Garu, WordType.TeForm, WordType.Iru, WordType.MasuStem, WordType.PoliteMasu, WordType.NeParticle)]
        [TestCase("行くらしくないですね", "行く", WordType.Rashii, WordType.NegativeNaiVerb, WordType.PoliteDesuVerb, WordType.NeParticle)]
        [TestCase("信じられないみたいだね", "信じる", WordType.PotentialPassive, WordType.NegativeNaiVerb, WordType.Mitai, WordType.Da, WordType.NeParticle)]
        [TestCase("信じられるが早いか", "信じる", WordType.PotentialPassive, WordType.GaHayaiKa)]
        [TestCase("信じられるがはやいか", "信じる", WordType.PotentialPassive, WordType.GaHayaiKa, WordType.GaHayaiKa)]
        [TestCase("言われるまえだよ", "言う", WordType.Passive, WordType.Mae, WordType.Da, WordType.YoParticle)]
        [TestCase("言われる前だよ", "言う", WordType.Passive, WordType.Mae, WordType.Da, WordType.YoParticle)]
        [TestCase("言わないよ", "言う", WordType.NegativeNaiVerb, WordType.YoParticle)]
        [TestCase("おいておいたことになったのだ", "おく", WordType.TeForm, WordType.Oku, WordType.PlainPast, WordType.KotoNiNaru, WordType.PlainPast, WordType.ExplanatoryNoParticle, WordType.Da)]
        [TestCase("おいておくことにした", "おく", WordType.TeForm, WordType.Oku, WordType.KotoNiSuru, WordType.PlainPast)]
        [TestCase("返したことなのですよ", "返す", WordType.PlainPast, WordType.KotoNominalizer, WordType.Da, WordType.ExplanatoryNoParticle, WordType.Da, WordType.PoliteDesuVerb, WordType.YoParticle)]
        [TestCase("帰ったのだよ", "帰る", WordType.PlainPast, WordType.ExplanatoryNoParticle, WordType.Da, WordType.YoParticle)]
        //[TestCase("殺されるな", "殺す", WordType.Passive, WordType.NaParticle)] // broken in original code
        [TestCase("はしゃぐことがあることがあるだろうよ", "はしゃぐ", WordType.OccasionalOccuranceAru, WordType.OccasionalOccuranceAru, WordType.Darou, WordType.YoParticle)]
        [TestCase("止めることができる", "止める", WordType.Potential)]
        [TestCase("止めることができているよ", "止める", WordType.Potential, WordType.TeForm, WordType.Iru, WordType.YoParticle)]
        [TestCase("止められるまでだよね", "止める", WordType.PotentialPassive, WordType.MadeParticle, WordType.Da, WordType.YoParticle, WordType.NeParticle)]
        [TestCase("停止せよ", "停止する", WordType.Imperative)]
        [TestCase("書ければ", "書く", WordType.Potential, WordType.BaForm)]
        [TestCase("離さなくない", "離す", WordType.NegativeNaiVerb, WordType.NegativeNaiVerb)]
        [TestCase("離さなくなさそうです", "離す", WordType.NegativeNaiVerb, WordType.NegativeNaiVerb, WordType.Appearance, WordType.Da, WordType.PoliteDesuVerb)]
        [TestCase("離さなかろう", "離す", WordType.NegativeNaiVerb, WordType.Volitional)]
        [TestCase("離さないべき", "離す", WordType.NegativeNaiVerb, WordType.Beki)]
        [TestCase("離さなかったらよければ", "離す", WordType.NegativeNaiVerb, WordType.Tara, WordType.Ii, WordType.Ii, WordType.BaForm)]
        [TestCase("来る", "来る")]
        [TestCase("来ない", "来る", WordType.NegativeNaiVerb)]
        [TestCase("来た", "来る", WordType.PlainPast)]
        [TestCase("来い", "来る", WordType.Imperative)]
        [TestCase("せず", "する", WordType.Zu)]
        [TestCase("しない", "する", WordType.NegativeNaiVerb)]
        [TestCase("しなければ", "する", WordType.NegativeNaiVerb, WordType.BaForm)]
        [TestCase("言っとけた", "言う", WordType.TeForm, WordType.Oku, WordType.Potential, WordType.PlainPast)]
        [TestCase("言って置かれた", "言う", WordType.TeForm, WordType.Oku, WordType.Oku, WordType.Passive, WordType.PlainPast)]
        [TestCase("確認すべきです", "確認する", WordType.Beki, WordType.Da, WordType.PoliteDesuVerb)]
        [TestCase("書けなさそうです", "書く", WordType.Potential, WordType.NegativeNaiVerb, WordType.Appearance, WordType.Da, WordType.PoliteDesuVerb)]
        [TestCase("離れていただけないでしょうか", "離れる", WordType.TeForm, WordType.Morau, WordType.PoliteItadaku, WordType.Potential, WordType.NegativeNaiVerb, WordType.Darou, WordType.PoliteDeshou, WordType.KaParticle)]
        [TestCase("離れてもらえないでしょうか", "離れる", WordType.TeForm, WordType.Morau, WordType.Potential, WordType.NegativeNaiVerb, WordType.Darou, WordType.PoliteDeshou, WordType.KaParticle)]
        [TestCase("離れてもらいたいです", "離れる", WordType.TeForm, WordType.Morau, WordType.MasuStem, WordType.Tai, WordType.PoliteDesuVerb)]
        [TestCase("励ます", "励ます")]
        [TestCase("話します", "話す", WordType.MasuStem, WordType.PoliteMasu)]
        [TestCase("話すです", "話す", WordType.PoliteDesuVerb)]
        [TestCase("信じます", "信じる", WordType.MasuStem, WordType.PoliteMasu)]
        [TestCase("信じるです", "信じる", WordType.PoliteDesuVerb)]
        [TestCase("行きません", "行く", WordType.MasuStem, WordType.PoliteMasen)]
        [TestCase("得ません", "得る", WordType.MasuStem, WordType.PoliteMasen)]
        [TestCase("語らないです", "語る", WordType.NegativeNaiVerb, WordType.PoliteDesuVerb)]
        [TestCase("語らないです", "語る", WordType.NegativeNaiVerb, WordType.PoliteDesuVerb)]
        [TestCase("弾けない", "弾く", WordType.Potential, WordType.NegativeNaiVerb)]
        [TestCase("集まりました", "集まる", WordType.MasuStem, WordType.PoliteMasu, WordType.PoliteMashita)]
        [TestCase("信じました", "信じる", WordType.MasuStem, WordType.PoliteMasu, WordType.PoliteMashita)]
        [TestCase("笑いませんでした", "笑う", WordType.MasuStem, WordType.PoliteMasen, WordType.PoliteMasenDeshita)]
        [TestCase("放った", "放る", WordType.PlainPast)]
        [TestCase("覚えた", "覚える", WordType.PlainPast)]
        [TestCase("言わなかった", "言う", WordType.NegativeNaiVerb, WordType.PlainPast)]
        [TestCase("照らなかった", "照る", WordType.NegativeNaiVerb, WordType.PlainPast)]
        [TestCase("咲いて", "咲く", WordType.TeForm)]
        [TestCase("消えて", "消える", WordType.TeForm)]
        [TestCase("解きまして", "解く", WordType.MasuStem, WordType.PoliteMasu, WordType.TeForm)]
        [TestCase("変わらなくて", "変わる", WordType.NegativeNaiVerb, WordType.TeForm)]
        [TestCase("打てば", "打つ", WordType.BaForm)]
        [TestCase("打たなければ", "打つ", WordType.NegativeNaiVerb, WordType.BaForm)]
        [TestCase("置かれる", "置く", WordType.Passive)]
        [TestCase("置かれることがあるよ", "置く", WordType.Passive, WordType.OccasionalOccuranceAru, WordType.YoParticle)]
        [TestCase("得られる", "得る", WordType.PotentialPassive)]
        [TestCase("帰れる", "帰る", WordType.Potential)]
        [TestCase("帰れなくて", "帰る", WordType.Potential, WordType.NegativeNaiVerb, WordType.TeForm)]
        [TestCase("帰れなければ", "帰る", WordType.Potential, WordType.NegativeNaiVerb, WordType.BaForm)]
        [TestCase("帰れました", "帰る", WordType.Potential, WordType.MasuStem, WordType.PoliteMasu, WordType.PoliteMashita)]
        [TestCase("放たれました", "放つ", WordType.Passive, WordType.MasuStem, WordType.PoliteMasu, WordType.PoliteMashita)]
        [TestCase("黙れ", "黙る", WordType.Imperative)]
        //[TestCase("いろ", "いる", WordType.Imperative)] // commented out because it was commented out in the original code
        [TestCase("食べよう", "食べる", WordType.Volitional)]
        [TestCase("殺されましょう", "殺す", WordType.Passive, WordType.MasuStem, WordType.PoliteMasu, WordType.PoliteMashou)]
        [TestCase("降りそう", "降りる", WordType.MasuStem, WordType.Appearance)]
        [TestCase("走れそう", "走る", WordType.Potential, WordType.MasuStem, WordType.Appearance)]
        [TestCase("殴られそう", "殴る", WordType.PotentialPassive, WordType.MasuStem, WordType.Appearance)]
        [TestCase("買えそう", "買う", WordType.Potential, WordType.MasuStem, WordType.Appearance)]
        [TestCase("書かれそう", "書く", WordType.Passive, WordType.MasuStem, WordType.Appearance)]
        [TestCase("走るそう", "走る", WordType.Hearsay)]
        [TestCase("得られるそう", "得る", WordType.PotentialPassive, WordType.Hearsay)]
        [TestCase("押されるそう", "押す", WordType.Passive, WordType.Hearsay)]
        [TestCase("食べれるそう", "食べる", WordType.Potential, WordType.Hearsay)]
        [TestCase("行かないそう", "行く", WordType.NegativeNaiVerb, WordType.Hearsay)]
        [TestCase("行かなかったそう", "行く", WordType.NegativeNaiVerb, WordType.PlainPast, WordType.Hearsay)]
        [TestCase("歌わせる", "歌う", WordType.Causative)]
        [TestCase("歌わせた", "歌う", WordType.Causative, WordType.PlainPast)]
        [TestCase("歌わす", "歌う", WordType.Causative, WordType.ShortenedCausative)]
        [TestCase("歌わせられた", "歌う", WordType.Causative, WordType.PotentialPassive, WordType.PlainPast)]
        [TestCase("歌わせない", "歌う", WordType.Causative, WordType.NegativeNaiVerb)]
        [TestCase("歌わせたら", "歌う", WordType.Causative, WordType.Tara)]
        [TestCase("歌わせられたら", "歌う", WordType.Causative, WordType.PotentialPassive, WordType.Tara)]
        [TestCase("歌わせなかったら", "歌う", WordType.Causative, WordType.NegativeNaiVerb, WordType.Tara)]
        [TestCase("放たれましたら", "放つ", WordType.Passive, WordType.MasuStem, WordType.PoliteMasu, WordType.Tara)]
        [TestCase("帰れたら", "帰る", WordType.Potential, WordType.Tara)]
        [TestCase("置かれたら", "置く", WordType.Passive, WordType.Tara)]
        [TestCase("歌わせられなきゃ", "歌う", WordType.Causative, WordType.PotentialPassive, WordType.NegativeNaiVerb, WordType.Nakya)]
        [TestCase("歌わせなきゃ", "歌う", WordType.Causative, WordType.NegativeNaiVerb, WordType.Nakya)]
        [TestCase("放たれなきゃ", "放つ", WordType.Passive, WordType.NegativeNaiVerb, WordType.Nakya)]
        [TestCase("放たれなくちゃ", "放つ", WordType.Passive, WordType.NegativeNaiVerb, WordType.Nakucha)]
        [TestCase("歌わせられた挙句", "歌う", WordType.Causative, WordType.PotentialPassive, WordType.PlainPast, WordType.Ageku)]
        [TestCase("歌いたい", "歌う", WordType.MasuStem, WordType.Tai)]
        [TestCase("歌いたくない", "歌う", WordType.MasuStem, WordType.Tai, WordType.NegativeNaiVerb)]
        [TestCase("歌いたくはない", "歌う", WordType.MasuStem, WordType.Tai, WordType.NegativeNaiVerb)]
        [TestCase("歌わせられたい", "歌う", WordType.Causative, WordType.PotentialPassive, WordType.MasuStem, WordType.Tai)]
        [TestCase("歌わせたい", "歌う", WordType.Causative, WordType.MasuStem, WordType.Tai)]
        [TestCase("歌わせないで", "歌う", WordType.Causative, WordType.NegativeNaiVerb, WordType.Naide)]
        [TestCase("食べさせられたかった", "食べる", WordType.Causative, WordType.PotentialPassive, WordType.MasuStem, WordType.Tai, WordType.PlainPast)]
        [TestCase("行くな", "行く", WordType.NaCommand)]
        [TestCase("信じるな", "信じる", WordType.NaCommand)]
        [TestCase("行くまい", "行く", WordType.NegativeVolitional)]
        [TestCase("信じるまい", "信じる", WordType.NegativeVolitional)]
        [TestCase("話している", "話す", WordType.TeForm, WordType.Iru)]
        [TestCase("話してある", "話す", WordType.TeForm, WordType.Aru)]
        [TestCase("話しておる", "話す", WordType.TeForm, WordType.Oru)]
        [TestCase("話していさせて", "話す", WordType.TeForm, WordType.Iru, WordType.Causative, WordType.TeForm)]
        [TestCase("離されて", "離す", WordType.Passive, WordType.TeForm)]
        [TestCase("離せて", "離す", WordType.Potential, WordType.TeForm)]
        [TestCase("得られて", "得る", WordType.PotentialPassive, WordType.TeForm)]
        [TestCase("撫でさせられていさせて", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.TeForm, WordType.Iru, WordType.Causative, WordType.TeForm)]
        [TestCase("書かれてあった", "書く", WordType.Passive, WordType.TeForm, WordType.Aru, WordType.PlainPast)]
        //[TestCase("書かれてなかった", "書く", WordType.Passive, WordType.TeForm, WordType.Aru, WordType.NegativeNaiVerb, WordType.PlainPast)] // broken in original code
        [TestCase("撫でさせられていさせなさい", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.TeForm, WordType.Iru, WordType.Causative, WordType.MasuStem, WordType.Nasai)]
        [TestCase("撫でさせられていさせな", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.TeForm, WordType.Iru, WordType.Causative, WordType.MasuStem, WordType.Nasai)]
        [TestCase("撫でさせられてはいさせな", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.TeForm, WordType.WaAfterTe, WordType.Iru, WordType.Causative, WordType.MasuStem, WordType.Nasai)]
        [TestCase("書かず", "書く", WordType.Zu)]
        [TestCase("書けず", "書く", WordType.Potential, WordType.Zu)]
        [TestCase("書かれず", "書く", WordType.Passive, WordType.Zu)]
        [TestCase("撫でさせられていさせず", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.TeForm, WordType.Iru, WordType.Causative, WordType.Zu)]
        [TestCase("撫でさせられず", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.Zu)]
        [TestCase("撫でさせられたく", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.MasuStem, WordType.Tai, WordType.Adverb)]
        [TestCase("撫でさせられたくなく", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.MasuStem, WordType.Tai, WordType.NegativeNaiVerb, WordType.Adverb)]
        [TestCase("撫でさせられたくはなく", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.MasuStem, WordType.Tai, WordType.NegativeNaiVerb, WordType.Adverb)]
        [TestCase("座ってはいる", "座る", WordType.TeForm, WordType.WaAfterTe, WordType.Iru)]
        [TestCase("されたくない", "する", WordType.Passive, WordType.MasuStem, WordType.Tai, WordType.NegativeNaiVerb)]
        [TestCase("書きません", "書く", WordType.MasuStem, WordType.PoliteMasen)]
        [TestCase("しませんでした", "する", WordType.MasuStem, WordType.PoliteMasen, WordType.PoliteMasenDeshita)]
        [TestCase("為さいませんでした", "為さる", WordType.MasuStem, WordType.PoliteMasen, WordType.PoliteMasenDeshita)]
        [TestCase("書いてください", "書く", WordType.TeForm, WordType.Kudasai)]
        [TestCase("撫でさせられぬ", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.NegativeNaiVerb, WordType.Nu)]
        [TestCase("撫でさせられぬよ", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.NegativeNaiVerb, WordType.Nu, WordType.YoParticle)]
        [TestCase("撫でさせられぬよね", "撫でる", WordType.Causative, WordType.PotentialPassive, WordType.NegativeNaiVerb, WordType.Nu, WordType.YoParticle, WordType.NeParticle)]
        [TestCase("仰いませんでした", "仰る", WordType.MasuStem, WordType.PoliteMasen, WordType.PoliteMasenDeshita)]
        [TestCase("話してあるだろう", "話す", WordType.TeForm, WordType.Aru, WordType.Darou)]
        [TestCase("話してあるでしょう", "話す", WordType.TeForm, WordType.Aru, WordType.Darou, WordType.PoliteDeshou)]
        [TestCase("行った方が良くないよ", "行う", WordType.PlainPast, WordType.HouGaIi, WordType.NegativeNaiVerb, WordType.YoParticle)]
        public void WorksForGrammarRule(string word, string expectedBase, params WordType[] derivations)
        {
            var bestResult = JpConj.Deconjugate(word).First();
            
            Assert.AreEqual(expectedBase, bestResult.Base);
            CollectionAssert.AreEqual(derivations, bestResult.DerivationPath);
        }
        
        
    }
}