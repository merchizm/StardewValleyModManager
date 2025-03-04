# Stardew Valley Mod Yöneticisi

Stardew Valley modlarınızı yönetmek için basit ve kullanıcı dostu bir uygulama.

## Özellikler

- Modları silmeden kolayca aktifleştirme ve devre dışı bırakma
- Doğrudan uygulama üzerinden SMAPI ile Stardew Valley'i başlatma
- Manifest.json dosyalarını kontrol ederek mod geçerliliğini doğrulama
- Faydalı Stardew Valley modlama kaynaklarına erişim
- Basit ve sezgisel arayüz

## Gereksinimler

- .NET Framework 4.7.2 veya daha yüksek
- SMAPI yüklü Stardew Valley oyunu
- Windows işletim sistemi

## Kurulum

1. En son sürümü [Releases](https://github.com/merchizm/StardewValleyModManager/releases) sayfasından indirin
2. Zip dosyasını bilgisayarınızda oyunun olduğu dizine bir konuma çıkarın
3. `StardewValleyModManager.exe` dosyasını çalıştırın

## Kullanım

### İlk Kurulum

1. Uygulamayı ilk çalıştırdığınızda, Stardew Valley oyun dizininizin yolunu ayarlamanız gerekecek
2. "Gözat" düğmesine tıklayın ve Stardew Valley kurulum klasörünüze (StardewModdingAPI.exe'nin bulunduğu yer) gidin
3. Uygulama, eğer zaten mevcut değilse "Mods" ve "DeactivatedMods" klasörlerini oluşturacaktır

### Modları Yönetme

- **Bir Modu Aktifleştirme**: "Devre Dışı Modlar" listesinden bir mod seçin ve "Aktifleştir" düğmesine tıklayın
- **Bir Modu Devre Dışı Bırakma**: "Aktif Modlar" listesinden bir mod seçin ve "Devre Dışı Bırak" düğmesine tıklayın
- **Oyunu Başlatma**: Aktif modlarınızla Stardew Valley'i başlatmak için "Oyunu Başlat" düğmesine tıklayın

### Modları Aktarma

Modları bilgisayarınızdan oyun dizinine aktarmak için:
1. Nexus Mods veya diğer kaynaklardan mod dosyalarını indirin
2. Mod dosyaları sıkıştırılmış bir formatta ise (zip, rar, vb.) çıkarın
3. Çıkarılan mod klasörünü Stardew Valley oyun dizininizdeki "Mods" klasörüne yerleştirin
   - Genellikle `C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley\Mods` konumunda bulunur
   - Veya oyun dizininizi bulmak için uygulamadaki "Gözat" işlevini kullanın
4. Uygulamayı yenilediğinizde mod, "Aktif Modlar" listesinde görünmelidir
5. Bir modu silmeden geçici olarak devre dışı bırakmak istiyorsanız, "Devre Dışı Bırak" düğmesini kullanın

### Kaynaklar

Uygulama, faydalı Stardew Valley modlama kaynaklarına hızlı bağlantılar sağlar:
- Stardew Valley Wiki
- Nexus Mods
- SMAPI Dokümantasyonu
- Stardew Valley Forumları
- Stardew Valley Discord

## Kaynak Kodundan Derleme

1. Depoyu klonlayın
2. Çözümü Visual Studio'da açın
3. Çözümü derleyin (Ctrl+Shift+B)
4. Uygulamayı çalıştırın (F5)

## Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen bir Pull Request göndermekten çekinmeyin.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için LICENSE dosyasına bakın.

## Teşekkürler

- ConcernedApe tarafından geliştirilen [Stardew Valley](https://www.stardewvalley.net/)
- [SMAPI](https://smapi.io/) - Stardew Modding API
