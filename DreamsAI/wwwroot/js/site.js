document.addEventListener("DOMContentLoaded", () => {
    // Анимация при зареждане на заглавието
    const title = document.querySelector("h1");
    title.style.opacity = "0";
    title.style.transition = "opacity 2s";
    setTimeout(() => {
        title.style.opacity = "1";
    }, 500);

    // Анимация за бутоните
    const buttons = document.querySelectorAll(".btn-custom");
    buttons.forEach((button, index) => {
        button.style.opacity = "0";
        button.style.transform = "translateY(20px)";
        button.style.transition = `opacity 1s ${index * 0.3}s, transform 1s ${index * 0.3}s`;
        setTimeout(() => {
            button.style.opacity = "1";
            button.style.transform = "translateY(0)";
        }, 500);
    });

    // Динамичен текст
    const subTitle = document.querySelector("p");
    const messages = [
        "Анализирайте сънищата си с AI.",
        "Запазвайте вашите сънища лесно.",
        "Присъединете се към нашата общност!"
    ];
    let messageIndex = 0;

    setInterval(() => {
        subTitle.textContent = messages[messageIndex];
        messageIndex = (messageIndex + 1) % messages.length;
    }, 4000);
});





