document.addEventListener("DOMContentLoaded", () => {
    // Анимация при зареждане на заглавието
    const title = document.querySelector("h1");
    if (title) {
        title.style.opacity = "0";
        title.style.transition = "opacity 2s ease-in-out";
        setTimeout(() => {
            title.style.opacity = "1";
        }, 500);
    }

    // Анимация за бутоните
    const buttons = document.querySelectorAll(".btn-custom");
    buttons.forEach((button, index) => {
        button.style.opacity = "0";
        button.style.transform = "translateY(20px)";
        button.style.transition = `opacity 1s ease-in-out ${index * 0.3}s, transform 1s ease-in-out ${index * 0.3}s`;
        setTimeout(() => {
            button.style.opacity = "1";
            button.style.transform = "translateY(0)";
        }, 500);
    });

    // Динамичен текст с по-плавна смяна
    const subTitle = document.querySelector("p");
    const messages = [
        "Анализирайте сънищата си с AI.",
        "Запазвайте вашите сънища лесно.",
        "Присъединете се към нашата общност!"
    ];
    let messageIndex = 0;

    if (subTitle) {
        setInterval(() => {
            subTitle.style.opacity = "0";
            setTimeout(() => {
                subTitle.textContent = messages[messageIndex];
                subTitle.style.opacity = "1";
                messageIndex = (messageIndex + 1) % messages.length;
            }, 500);
        }, 4000);
    }
});




