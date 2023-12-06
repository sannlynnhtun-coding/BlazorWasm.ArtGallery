﻿//using BlazorWasm.ArtGallery.Models;
using BlazorWasm.ArtGallery.Models;
using Newtonsoft.Json;

namespace BlazorWasm.ArtGallery.Services;

public class ArtGalleryService
{
    public List<ArtistModel> GetArtist => GetData<ArtistModel>(Tbl_Artist);
    public List<GalleryModel> GetGallery => GetData<GalleryModel>(Tbl_Gallery);
    public List<ArtModel> GetArt => GetData<ArtModel>(Tbl_Art);

    public List<ArtAndArtistModel> ShowArtLst()
    {
        List<ArtAndArtistModel> artList = new();
        var getGalleryist = GetGallery;
        foreach (var item in getGalleryist)
        {
            var getItem = GetArt.FirstOrDefault(x => x.ArtId == item.ArtId);
            getItem.ArtPath = $"img/{getItem.ArtPath}";
            var model = new ArtAndArtistModel
            {
                ArtId = getItem.ArtId,
                ArtDescription = getItem.ArtDescription,
                ArtName = getItem.ArtName,
                ArtistId = item.ArtistId,
                ArtPath = getItem.ArtPath
            };
            artList.Add(model);
        }
        return artList;
    }

    public ArtAndArtistProfileModel ShowArtLstByArtist(int artistId)
    {
        var artLst = ShowArtLst().Where(x => x.ArtistId == artistId).ToList();
        var artist = GetArtist.FirstOrDefault(x => x.ArtistId == artistId);
        var model = new ArtAndArtistProfileModel
        {
            ArtAndArtistLst = artLst,
            Artist = artist ?? null
        };
        return model;
    }
    private List<T> GetData<T>(string jsonStr)
    {
        return JsonConvert.DeserializeObject<List<T>>(jsonStr);
    }

    private static string Tbl_Artist = @"[
 {
  ""ArtistId"": 1,
  ""ArtistName"": ""MMarina"",
  ""ArtistProfile"": ""https://scontent.fmdl4-4.fna.fbcdn.net/v/t39.30808-1/385257389_267940642887185_460994790741669571_n.jpg?stp=dst-jpg_s480x480&_nc_cat=105&ccb=1-7&_nc_sid=11e7ab&_nc_eui2=AeHEYgAxMoAAiNfgH3gOGXjW0kcvk0VTIUbSRy-TRVMhRrPwQf1hI-0Vy6i34K75FeRoORBlGacR_Upky9kphc6y&_nc_ohc=5mD81YRDRDwAX_x-ewC&_nc_ht=scontent.fmdl4-4.fna&oh=00_AfAcVKeCkbY2d0UyQIf2HNg5_kNtO5-mtykZne05q1-BjQ&oe=65769A31""
 },
 {
  ""ArtistId"": 2,
  ""ArtistName"": ""YellZawHlaing"",
  ""ArtistProfile"": ""https://scontent.fmdl4-4.fna.fbcdn.net/v/t39.30808-1/391717080_314939281263191_7825732557761776530_n.jpg?stp=dst-jpg_s480x480&_nc_cat=106&ccb=1-7&_nc_sid=5740b7&_nc_eui2=AeGXXtde7xrRRWBh0D4ddxsS_7kScUpvTw7_uRJxSm9PDuZe7Gq9_2KFI6uhwoMYkmvnr6pJPo8j6Q9kkJvIphnS&_nc_ohc=nQvpGnMo6zkAX8V6FU-&_nc_ht=scontent.fmdl4-4.fna&oh=00_AfCXVl119BT84Z2oQRiHO116OBKUO9ueXBvMcO1D2EqCRQ&oe=6574F3C6""
 },
 {
  ""ArtistId"": 3,
  ""ArtistName"": ""YoonNaDi"",
  ""ArtistProfile"": """"
 },
 {
  ""ArtistId"": 4,
  ""ArtistName"": ""Zenkei"",
  ""ArtistProfile"": """"
 },
 {
  ""ArtistId"": 5,
  ""ArtistName"": ""Thiri"",
  ""ArtistProfile"": """"
 },
 {
  ""ArtistId"": 6,
  ""ArtistName"": ""Thinthazin"",
  ""ArtistProfile"": """"
 }
 ]";

    private static string Tbl_Gallery = @"[
 {
  ""Id"": 1,
  ""ArtistId"": 1,
  ""ArtId"": 1
 },
 {
  ""Id"": 2,
  ""ArtistId"": 1,
  ""ArtId"": 2
 },
 {
  ""Id"": 3,
  ""ArtistId"": 1,
  ""ArtId"": 3
 },
 {
  ""Id"": 4,
  ""ArtistId"": 1,
  ""ArtId"": 4
 },
 {
  ""Id"": 5,
  ""ArtistId"": 1,
  ""ArtId"": 5
 },
 {
  ""Id"": 6,
  ""ArtistId"": 2,
  ""ArtId"": 6
 },
 {
  ""Id"": 7,
  ""ArtistId"": 3,
  ""ArtId"": 7
 },
 {
  ""Id"": 8,
  ""ArtistId"": 4,
  ""ArtId"": 8
 },
 {
  ""Id"": 9,
  ""ArtistId"": 5,
  ""ArtId"": 9
 },
 {
  ""Id"": 10,
  ""ArtistId"": 6,
  ""ArtId"": 10
 },
 {
  ""Id"": 11,
  ""ArtistId"": 6,
  ""ArtId"": 11
 },
 {
  ""Id"": 12,
  ""ArtistId"": 6,
  ""ArtId"": 12
 }
]";

    private static string Tbl_Art = @"[
 {
  ""ArtId"": 1,
  ""ArtName"": ""Marina"",
  ""ArtDescription"": ""ခံစားချက် က သူငယ်ချင်း အတွက် ဆွဲပေးထားတာပါ အမှတ်တရ ဖြစ်စေချင်လို့ပါ"",
  ""ArtPath"": ""1.jpg""
 },
 {
  ""ArtId"": 2,
  ""ArtName"": ""Kudae"",
  ""ArtDescription"": ""ခံစားချက် က သူငယ်ချင်း အတွက် ဆွဲပေးထားတာပါ အမှတ်တရ ဖြစ်စေချင်လို့ပါ"",
  ""ArtPath"": ""2.jpg""
 },
 {
  ""ArtId"": 3,
  ""ArtName"": ""Kudae1"",
  ""ArtDescription"": ""ခံစားချက် က သူငယ်ချင်း အတွက် ဆွဲပေးထားတာပါ အမှတ်တရ ဖြစ်စေချင်လို့ပါ"",
  ""ArtPath"": ""3.jpg""
 },
 {
  ""ArtId"": 4,
  ""ArtName"": ""Kudae2"",
  ""ArtDescription"": ""ခံစားချက် က သူငယ်ချင်း အတွက် ဆွဲပေးထားတာပါ အမှတ်တရ ဖြစ်စေချင်လို့ပါ"",
  ""ArtPath"": ""4.jpg""
 },
 {
  ""ArtId"": 5,
  ""ArtName"": 3,
  ""ArtDescription"": ""ခံစားချက် က သူငယ်ချင်း အတွက် ဆွဲပေးထားတာပါ အမှတ်တရ ဖြစ်စေချင်လို့ပါ"",
  ""ArtPath"": ""5.jpg""
 },
 {
  ""ArtId"": 6,
  ""ArtName"": ""Tick Tick Boom"",
  ""ArtDescription"": ""အာ့ဇာတ်ကားကြည့်ပီး Andrew Garfield ရဲ့ ဘဝလောကဓံကို ပီပြင်အောင်ရိုက်ထားဝာာ သဘောကျပီး"",
  ""ArtPath"": ""6.jpg""
 },
 {
  ""ArtId"": 7,
  ""ArtName"": ""NotOnlyDoodle"",
  ""ArtDescription"": ""Not Only Doodle ( Doodle ပဲမဟုတ်ဘူး ) \n\nဒီပန်းချီကားကို Doodle ပဲမဟုတ်ဘူး ဆိုတဲ့ခေါင်းစဉ်လေးပေးထားရတဲ့အကြောင်းကတော့ Doodle Art နဲ့ပတ်သတ်ပြီး တစ်ချို့သောသူတွေ အမြင်မှာ Doodle ဟာအခြေခံတွေ မလိုဘူး ပုံဆွဲတတ်ဖို့မလိုဘူး၊ ပုံမဆွဲတတ် ပန်းချီအခြေခံတွေမတတ်လည်း Doodle Art ကိုဖန်တီးလို့ရတယ်ဆိုပေမဲ့ Doodle Art ဆိုတာတကယ်ရှာဖွေနိုင်ရင် အလွန်အင်မတန်မှ စိတ်ဝင်စားစရာကောင်းတဲ့ Art style တစ်မျိုးဖြစ်ပါတယ်။ ရှာဖွေလေတွေ့ရှိလေ၊ လေ့လာလေ နက်နဲလေဆိုတဲ့ အနုပညာတစ်မျိုးပါပဲ။ ပန်းချီကို ပုံစံမျိုးစုံနဲ့ ရှုမြင်လက်ခံကြတဲ့အထဲမှာမှ\nDoodle ဆွဲရင်ပန်းချီဆရာမဟုတ်ဘူး Doodle ပုံ က ပန်းချီကားမဖြစ်နိုင်ဘူး Realism တွေဆွဲမှ ပန်းချီကားဖြစ်တယ်လို့သတ်မှတ်တတ်တဲ့သူများလဲရှိပြီးတော့ Realism တွေကြီးပဲဆွဲရင်လဲ ဓာတ်ပုံကိုပဲကြည့်ပြီးဆွဲတတ်တယ် ကိုယ်ပိုင်ဖန်တီးမှုမရှိဘူး တွေးခေါ်မှုမရှိဘူးဆိုပြီး သတ်မှတ်တတ်သောသူများလဲရှိပါသည်။ ထို့ကြောင့် Doodle Art နဲ့အတူ Realism ဆန်တဲ့ Still life နဲ့ Object တွေကိုပါ ပန်းချီကားထဲတွင် ထည့်သွင်းရေးချယ်ဖို့ ဆုံးဖြတ်ပြီး ဒီပန်းချီကားကို ဖန်တီးဖြစ်ခဲ့ပါတယ်ခင်ဗျာ။"",
  ""ArtPath"": ""7.jpg""
 },
 {
  ""ArtId"": 8,
  ""ArtName"": ""Break Up"",
  ""ArtDescription"": ""Title - Break Up\n\nသေကွဲရယ် ၊ ရှင်ကွဲရယ် တစ်နည်းနည်းသောကွဲခြင်းနဲ့ ဆက်ဆံရေးတွေဟာ မတော်တဆကျောခိုင်းရပ်မိကြလိမ့်ဦးမယ်။\nမတည်မြဲခြင်းကြားမှာ ငါတို့ဟာ ပျော်ခဲ့ဖူးမယ် ၊ ငိုခဲ့ဖူးမယ် ၊ လွမ်းခဲ့ဖူးမယ် ၊ ဒေါသတွေလည်းထွက်ခဲ့ဖူးကြမယ်။ \nသမုဒယသစ္စာကိုလက်ကိုင်ထားရင်း နှင်း‌ဆီတွေကြွေတာကိုလည်း ငါတို့တွေ ကြည်ကြည်နူးနူးကြည့်ဖူးကြလိမ့်မယ်။\nဘယ်လိုခံစားပြီးဆွဲထားလဲဆို‌တော့ သီချင်းစာသားတစ်ကြောင်းကို ကြားပြီးတဲ့နောက်မှာ ဒီလိုလေးဆွဲဖို့ idea ရခဲ့ပါတယ်။  ပန်းချီကားရဲ့ အဓိပ္ပာယ်ကတော့ မပြောတော့ဘူးနော်။ ဒီပန်းချီကားကိုကြည့်ရင်းနဲ့ ကြည့်သူမှာပေါ်လာတဲ့ ခံစားချက် ၊ ကြည့်သူ သဘောပေါက်သွားတဲ့ အကြောင်းအရာဟာ သူ့ရဲ့ အဓိပ္ပာယ်ပါပဲ။"",
  ""ArtPath"": ""8.jpg""
 },
 {
  ""ArtId"": 9,
 ""ArtName"": ""ဘုံကဖီး"",
  ""ArtDescription"": ""Title  ဘုံကဖီး\nပုံကတော့အသိ ကဗျာဆရာလဲဟုတ် ပန်းချီဆရာလဲဖြစ်တဲ့ ကိုအီလစ်တို့ရဲ့ဘုံကဖီးလေးပါပဲ\nပန်းချီကားလေးအဓိပ္ပာယ်ကတော့ တစ်ပတ်မှာ36နာရီလက်ဖက်ရည်ဆိုင်ထိုင်ခဲ့တယ် \nတစ်ဖြည်းဖြည်းနဲ့ လက်ဖက်ရည်ဆိုင်ကခုံတွေလိုတို့ဘဝတွေပုဝင်နေခဲ့ ဘယ်လိုမှမေ့ပျောက်လို့မရတဲ့နေ့တွေ တစ်ဟုန်းထိုးမောင်းထွက်သွားတဲ့ဘဝတွေ \nတစ်ဘဝလုံးပုံအောခဲ့တဲ့ကစားဝိုင်း ငါတို့အားလုံးရဲ့ ဘုံကဖီးပါပဲ။"",
  ""ArtPath"": ""9.jpg""
 },
 {
  ""ArtId"": 10,
  ""ArtName"": ""ကနုဒ"",
  ""ArtDescription"": ""Title - ကနုဒ\nကြာပန်းတို့၏ဟန်ကိုယူ၍ကွေး၊ကော့၊ခွေ၊လိပ် ကာအလှအပတန်ဆာဆင်ထားသောကနုတ်ပန်းများနှင့်ကြာပန်း၏အလှတရားကိုခံစားသက်ဝင်ရင်း..."",
  ""ArtPath"": ""10.jpg""
 },
 {
  ""ArtId"": 11,
  ""ArtName"": ""rose , nightingale and a song"",
  ""ArtDescription"": ""Title- rose , nightingale and a song\n\nသီချင်းဆိုရတာကြိုက်တာမို့ပါ။ ပန်းကလဲနှင်းဆီပန်းကြိုက်လို့ပါ။"",
  ""ArtPath"": ""11.jpg""
 },
 {
  ""ArtId"": 12,
  ""ArtName"": ""midnight dream"",
  ""ArtDescription"": ""Title: midnight dream\n\nAbout the dream of young people \ncovid နဲ့ politics အခြေနေတွေခက်ခက်ခဲခဲဖြတ်ကျော်ခဲ့ရတဲ့လူငယ်တွေအတွက်ပါ။"",
  ""ArtPath"": ""12.jpg""
 }
]";
}
