document.addEventListener('DOMContentLoaded', function () {
    const featureItems = document.querySelectorAll('.features li');
    const featureImages = document.querySelector('.feature-images img');

    featureItems.forEach(item => {
        item.addEventListener('mouseenter', function () {
            const imageSrc = item.getAttribute('data-image');
            featureImages.src = imageSrc;
            featureImages.style.display = 'block';
        });

        item.addEventListener('mouseleave', function () {
            featureImages.style.display = 'none';
        });
    });
});
