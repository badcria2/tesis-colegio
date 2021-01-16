(window["canvasWebpackJsonp"]=window["canvasWebpackJsonp"]||[]).push([[411],{"7LJr":function(i,e,s){"use strict"
var n=s("ouhR")
var a=s.n(n)
a.a.fn.loadingImg=function(i){if(!this||0===this.length)return this
const e=this.filter(":first")
let s
if("hide"===i||"remove"===i){e.children(".loading_image").remove()
s=e.data("loading_images")||[]
s.forEach(i=>{i&&i.remove()})
e.data("loading_images",null)
return this}if("remove_once"===i){e.children(".loading_image").remove()
s=e.data("loading_images")||[]
const i=s.pop()
i&&i.remove()
e.data("loading_images",s)
return this}"register_image"==i&&3==arguments.length&&(a.a.fn.loadingImg.image_files[arguments[1]]=arguments[2])
i=a.a.extend({},a.a.fn.loadingImg.defaults,i)
let n=a.a.fn.loadingImg.image_files.normal
i.image_size&&a.a.fn.loadingImg.image_files[i.image_size]&&(n=a.a.fn.loadingImg.image_files[i.image_size])
i.paddingTop&&(i.vertical=i.paddingTop)
let o=0
if(i.vertical)if("top"==i.vertical);else if("bottom"==i.vertical)o=e.outerHeight()
else if("middle"==i.vertical)o=e.outerHeight()/2-n.height/2
else{o=parseInt(i.vertical,10)
isNaN(o)&&(o=0)}let r=0
if(i.horizontal)if("left"==i.horizontal);else if("right"==i.horizontal)r=e.outerWidth()-n.width
else if("middle"==i.horizontal)r=e.outerWidth()/2-n.width/2
else{r=parseInt(i.horizontal,10)
isNaN(r)&&(r=0)}const t=e.zIndex()+1
const l=a()(document.createElement("div")).addClass("loading_image_holder")
const d=a()(document.createElement("img")).attr("src",n.url)
l.append(d)
s=e.data("loading_images")||[]
s.push(l)
e.data("loading_images",s)
if(e.css("position")&&"static"!=e.css("position")){l.css({zIndex:t,position:"absolute",top:o,left:r})
e.append(l)}else{const s=e.offset()
let n=s.top,d=s.left
i.vertical&&(n+=o)
i.horizontal&&(d+=r)
l.css({zIndex:t,position:"absolute",top:n,left:d})
a()("body").append(l)}return a()(this)}
a.a.fn.loadingImg.defaults={paddingTop:0,image_size:"normal",vertical:0,horizontal:0}
a.a.fn.loadingImg.image_files={normal:{url:"/images/ajax-loader.gif",width:32,height:32},small:{url:"/images/ajax-loader-small.gif",width:16,height:16}}
a.a.fn.loadingImage=a.a.fn.loadingImg},"L/di":function(i,e,s){"use strict"
s.r(e)
var n=s("ouhR")
var a=s.n(n)
class o{constructor(i,e){this.$loginForm=i
this.$forgotPasswordForm=e}switchToLogin(){this.$forgotPasswordForm.hide()
this.$loginForm.show()
this.$loginForm.find("input:visible:first").focus()}switchToForgotPassword(){this.$loginForm.hide()
this.$forgotPasswordForm.show()
this.$forgotPasswordForm.find("input:visible:first").focus()}}var r=o
var t=s("3lLS")
var l=s.n(t)
var d=s("pQTu")
var _=s("m0r6")
Object(_["a"])(JSON.parse('{"ar":{"pseudonyms":{"login":{"invalid_login":"تسجيل دخول غير صالح","invalid_password":"كلمة مرور غير صالحة","parent_signup":"تسجيل ولي الأمر"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"سيتم إرسال إرشادات استعادة كلمة المرور إلى *%{email_address}*. قد يستغرق هذا حتى 30 دقيقة. تأكد من التحقق من صندوق البريد العشوائي."},"ca":{"pseudonyms":{"login":{"invalid_login":"Inici de sessió no vàlid","invalid_password":"Contrasenya no vàlida","parent_signup":"Registre principal"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Les instruccions per recuperar la vostra contrasenya s\'enviaran a *%{email_address}*. Pot ser que trigui fins a 30 minuts. Assegureu-vos de comprovar la bústia de correu brossa."},"cy":{"pseudonyms":{"login":{"invalid_login":"Mewngofnodi annilys","invalid_password":"Cyfrinair annilys","parent_signup":"Cofrestru Rhieni"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Bydd eich cyfarwyddiadau adfer cyfrinair yn cael ei anfon at *%{email_address}*. Gall hyn gymryd hyd at 30munud. Cofiwch edrych yn eich blwch sbam."},"da":{"pseudonyms":{"login":{"invalid_login":"Ugyldigt login","invalid_password":"Ugyldig adgangskode","parent_signup":"Forældretilmelding"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Dine instruktioner til gendannelse af adgangskode sendes til *%{email_address}*. Dette kan tage op til 30 minutter. Sørg for at tjekke i din uønskede post."},"da-x-k12":{"pseudonyms":{"login":{"invalid_login":"Ugyldigt login","invalid_password":"Ugyldig adgangskode","parent_signup":"Forældretilmelding"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Dine instruktioner til gendannelse af adgangskode sendes til *%{email_address}*. Dette kan tage op til 30 minutter. Sørg for at tjekke i din uønskede post."},"de":{"pseudonyms":{"login":{"invalid_login":"Ungültige Zugangskennung","invalid_password":"Ungültiges Kennwort","parent_signup":"Elternanmeldung"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Die Anweisung zur Wiederherstellung Ihres Kennworts werden an *%{email_address}* gesendet. Das kann bis zu 30 Minuten in Anspruch nehmen. Bitte überprüfen Sie auch Ihren Spam-Ordner."},"el":{"pseudonyms":{"login":{"invalid_login":"Μη έγκυρη σύνδεση","invalid_password":"Μη έγκυρος κωδικός πρόσβασης","parent_signup":"Εγγραφή Γονέα"}}},"en-AU":{"pseudonyms":{"login":{"invalid_login":"Invalid login","invalid_password":"Invalid password","parent_signup":"Parent Signup"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Your password recovery instructions will be sent to *%{email_address}*. This may take up to 30 minutes. Make sure to check your spam box."},"en-AU-x-unimelb":{"pseudonyms":{"login":{"invalid_login":"Invalid login","invalid_password":"Invalid password","parent_signup":"Parent Signup"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Your password recovery instructions will be sent to *%{email_address}*. This may take up to 30 minutes. Make sure to check your spam box."},"en-CA":{"pseudonyms":{"login":{"invalid_login":"Invalid login","invalid_password":"Invalid password","parent_signup":"Parent Signup"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Your password recovery instructions will be sent to *%{email_address}*. This may take up to 30 minutes. Make sure to check your spam box."},"en-GB":{"pseudonyms":{"login":{"invalid_login":"Invalid login","invalid_password":"Invalid password","parent_signup":"Parent Signup"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Your password recovery instructions will be sent to *%{email_address}*. This may take up to 30 minutes. Make sure to check your spam box."},"en-GB-x-lbs":{"pseudonyms":{"login":{"invalid_login":"Invalid login","invalid_password":"Invalid password","parent_signup":"Parent Signup"}}},"en-GB-x-ukhe":{"pseudonyms":{"login":{"invalid_login":"Invalid login","invalid_password":"Invalid password","parent_signup":"Parent Signup"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Your password recovery instructions will be sent to *%{email_address}*. This may take up to 30 minutes. Make sure to check your spam box."},"es":{"pseudonyms":{"login":{"invalid_login":"Inicio de Sesión Inválida","invalid_password":"Contraseña inválida","parent_signup":"Registro para padres"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Las instrucciones para que recupere su contraseña se enviarán a *%{email_address}*. Esto podría tardar hasta 30 minutos. Asegúrese de verificar su casilla de correo no deseado."},"fa":{"pseudonyms":{"login":{"invalid_login":"ورود معتبر نیست","invalid_password":"رمز عبور معتبر نیست","parent_signup":"ثبت نام والدین"}}},"fi":{"pseudonyms":{"login":{"invalid_login":"Virheellinen sisäänkirjautumistunnus","invalid_password":"Virheellinen salasana","parent_signup":"Vanhempien rekisteröityminen"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Salasanasi palautusohjeet lähetetään kohteeseen *%{email_address}*. Tämä saattaa kestää 30 minuuttia. Varmista, että tarkistat roskapostilaatikon."},"fr":{"pseudonyms":{"login":{"invalid_login":"Nom de connexion incorrect","invalid_password":"Mot de passe non valide","parent_signup":"Inscription des parents"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Les instructions de récupération de votre mot de passe seront envoyées à *%{email_address}*. Cela peut prendre jusqu’à 30 minutes. Pensez à bien vérifier votre dossier de spams."},"fr-CA":{"pseudonyms":{"login":{"invalid_login":"Nom de connexion incorrect","invalid_password":"Mot de passe non valide","parent_signup":"Inscription parentale"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Vos instructions de récupération de mot de passe seront envoyées à *%{email_address}*. Ceci peut prendre jusqu’à 30 minutes. Assurez-vous de vérifier votre boîte de pourriels."},"he":{"pseudonyms":{"login":{"invalid_login":"לוג-אין שגוי","invalid_password":"סיסמה שגויה","parent_signup":"הזדהות הורה"}}},"ht":{"pseudonyms":{"login":{"invalid_login":"Koneksyon envalid","invalid_password":"Modpas envalid","parent_signup":"Enskripsyon Paran"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Y ap voye enstriksyon pou ka rekipere modpas ou sou *%{email_address}*. Sa kapab pran jiska 30 minit. Asire w ou gade nan imèl endezirab yo."},"hu":{"pseudonyms":{"login":{"invalid_login":"Sikertelen bejelentkezés","invalid_password":"Helytelen jelszó","parent_signup":"Szülői regisztráció"}}},"hy":{"pseudonyms":{"login":{"invalid_login":"Սխալ մուտքային անուն","invalid_password":"Սխալ գաղտնաբառ","parent_signup":"Ծնողի գրանցում"}}},"is":{"pseudonyms":{"login":{"invalid_login":"Ógild innskráning","invalid_password":"Ógilt lykilorð","parent_signup":"Skráning foreldris"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Leiðbeiningar um endurstillingu aðgangsorðs verða sendar í *%{email_address}*. Það gæti tekið allt að 30 mínútur. Passaðu að athuga í amapósthólfið þitt."},"it":{"pseudonyms":{"login":{"invalid_login":"Accesso non valido","invalid_password":"Password non valido","parent_signup":"Registrazione genitore"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Le istruzioni per il recupero della tua password saranno inviate a *%{email_address}*. Questo processo potrebbe richiedere fino a 30 minuti. Assicurati di controllare la cartella dello spam."},"ja":{"pseudonyms":{"login":{"invalid_login":"無効なログインです","invalid_password":"無効なパスワードです","parent_signup":"親のサインアップ"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"パスワードリカバリ手順が *%{email_address}* に送信されます。これには最大 30 分かかる場合があります。迷惑メールをチェックするようにしてください。"},"ko":{"pseudonyms":{"login":{"invalid_login":"유효하지 않은 로그인","invalid_password":"유효하지 않은 암호","parent_signup":"부모 등록"}}},"mi":{"pseudonyms":{"login":{"invalid_login":"Ehara tēnei i te takiurutanga tika","invalid_password":"kupuhipa muhu","parent_signup":"mātua haina"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Tō kupuhuna whakaora tohutohu ka tukuna atu kī *%{email_address}*. Ka mahi pea tēnei i roto i te 30 meneti. Kia mau me tīpako tō poaka mokumahu."},"nb":{"pseudonyms":{"login":{"invalid_login":"Ugyldig logg inn","invalid_password":"Ugyldig passord","parent_signup":"Påmelding for foreldre"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Instruksjoner for gjenoppretting av passord blir sendt til *%{email_address}*. Dette kan ta opptil 30 minutter. Sørg for å sjekke spaminnboksen."},"nb-x-k12":{"pseudonyms":{"login":{"invalid_login":"Ugyldig logg inn","invalid_password":"Ugyldig passord","parent_signup":"Påmelding for foreldre"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Instruksjoner for gjenoppretting av passord blir sendt til *%{email_address}*. Dette kan ta opptil 30 minutter. Sørg for å sjekke spaminnboksen."},"nl":{"pseudonyms":{"login":{"invalid_login":"Ongeldige aanmelding","invalid_password":"Ongeldig wachtwoord","parent_signup":"Ouderlijke aanmelding"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"De instructies voor wachtwoordherstel worden verzonden naar *%{email_address}*. Dat kan 30 minuten duren. Vergeet niet je map met spam te controleren."},"nn":{"pseudonyms":{"login":{"invalid_login":"Ugyldig pålogging","invalid_password":"Ugyldig passord","parent_signup":"Registrering for foreldre"}}},"pl":{"pseudonyms":{"login":{"invalid_login":"Nieprawidłowa nazwa logowania","invalid_password":"Niepoprawne hasło","parent_signup":"Rejestracja rodziców"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Instrukcję odzyskiwania hasła otrzymasz pod adresem *%{email_address}*. Może to potrwać maksymalnie 30 minut. Sprawdź skrzynkę ze spamem."},"pt":{"pseudonyms":{"login":{"invalid_login":"Login inválido","invalid_password":"Senha inválida","parent_signup":"Inscrição de pais"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"As instruções de recuperação da sua palavra-passe serão enviadas para *%{email_address}*. Isto pode demorar até 30 minutos. Certifique-se de verificar a sua caixa de spam."},"pt-BR":{"pseudonyms":{"login":{"invalid_login":"Login inválido","invalid_password":"Senha inválida","parent_signup":"Registro matriz"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Suas instruções de recuperação de senha serão enviadas para *%{email_address}*. Isso pode levar até 30 minutos. Certifique-se de verificar sua caixa de spam."},"ru":{"pseudonyms":{"login":{"invalid_login":"Неверные данные входа","invalid_password":"Неверный пароль","parent_signup":"Регистрация на родительском уровне"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Инструкции по восстановлению вашего пароля будут отправлены на *%{email_address}*. Это может занять до 30 минут. Не забудьте проверить папку для спама."},"sl":{"pseudonyms":{"login":{"invalid_login":"Neveljavna prijava","invalid_password":"Neveljavno geslo","parent_signup":"Včlanitev starša"}}},"sv":{"pseudonyms":{"login":{"invalid_login":"Ogiltig inloggning","invalid_password":"Ogiltigt lösenord","parent_signup":"Registrering för förälder"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Återställningsinstruktioner för ditt lösenord kommer att skickas till *%{email_address}*. Detta kan ta upp till 30 minuter. Se till att kontrollera din skräppostmapp."},"sv-x-k12":{"pseudonyms":{"login":{"invalid_login":"Ogiltig inloggning","invalid_password":"Ogiltigt lösenord","parent_signup":"Registrering för förälder"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"Återställningsinstruktioner för ditt lösenord kommer att skickas till *%{email_address}*. Detta kan ta upp till 30 minuter. Se till att kontrollera din skräppostmapp."},"tr":{"pseudonyms":{"login":{"invalid_login":"Oturum açma işlemi geçersiz","invalid_password":"Geçersiz şifre","parent_signup":"Ebeveyn Kayıt olma"}}},"uk":{"pseudonyms":{"login":{"invalid_login":"Невірний логін","invalid_password":"Невірний пароль","parent_signup":"реєстрація батьків"}}},"zh-Hans":{"pseudonyms":{"login":{"invalid_login":"登录信息无效","invalid_password":"密码无效","parent_signup":"父级注册"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"您的密码找回说明将发送到 *%{email_address}*。可能需要最多 30 分钟。请务必查看您的垃圾邮件文件夹。"},"zh-Hant":{"pseudonyms":{"login":{"invalid_login":"無效的登入","invalid_password":"無效的密碼","parent_signup":"家長註冊"}},"your_password_recovery_instructions_will_be_sent_t_1b7991f5":"您的重設密碼指示將傳送至 *%{email_address}*。最多可能需要 30 分鐘。請務必檢查您的垃圾郵件箱。"}}'))
s("jQeR")
s("0sPK")
var p=d["default"].scoped("pseudonyms.login")
var u=s("5Ky4")
var g=s("X7Ws")
s("phXn")
s("Z+Ib")
s("7LJr")
s("MWZS")
a()("#coenrollment_link").click((function(i){i.preventDefault()
const e=a()(this).data("template")
const s=a()(this).data("path")
Object(g["a"])(e,p.t("parent_signup","Parent Signup"),s)}))
a()(".field-with-fancyplaceholder input").fancyPlaceholder()
a()("#forgot_password_form").formSubmit({object_name:"pseudonym_session",required:["unique_id_forgot"],beforeSubmit(i){a()(this).loadingImage()},success(i){a()(this).loadingImage("remove")
a.a.flashMessage(Object(u["a"])(p.t("Your password recovery instructions will be sent to *%{email_address}*. This may take up to 30 minutes. Make sure to check your spam box.",{wrappers:["<b>$1</b>"],email_address:a()(this).find(".email_address").val()})),9e5)
a()("ul#flash_message_holder button.close_link").focus()},error(i){a()(this).loadingImage("remove")}})
a()("#login_form").submit((function(i){const e=a()(this).getFormData({object_name:"pseudonym_session"})
let s=true
if(!e.unique_id||e.unique_id.length<1){a()(this).formErrors({unique_id:p.t("invalid_login","Invalid login")})
s=false}else if(!e.password||e.password.length<1){a()(this).formErrors({password:p.t("invalid_password","Invalid password")})
s=false}return s}))
l()(()=>{const i=new r(a()("#login_form"),a()("#forgot_password_form"))
a()(".forgot_password_link").click(e=>{e.preventDefault()
return i.switchToForgotPassword()})
a()(".login_link").click(e=>{e.preventDefault()
return i.switchToLogin()})})},phXn:function(i,e,s){"use strict"
var n=s("ouhR")
var a=s.n(n)
a.a.fn.fancyPlaceholder=function(){let i,e=[]
function s(){a.a.each(e,(i,e)=>{e[1][e[0].val()?"hide":"show"]()})}return this.each((function(){const n=a()(this),o=a()("label[for="+n.attr("id")+"]")
o.addClass("placeholder").wrapInner("<span/>").css({"font-family":n.css("font-family"),"font-size":n.css("font-size")})
n.focus(()=>{o.addClass("focus",300)}).blur(()=>{o.removeClass("focus",300)}).bind("keyup",s)
try{a()("input:focus").get(0)==this&&n.triggerHandler("focus")}catch(i){}e.push([n,o])
i||window.setInterval(s,100)}))}}}])

//# sourceMappingURL=login-c-bd5dbde5e3.js.map