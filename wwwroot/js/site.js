document.addEventListener('DOMContentLoaded', () => {
    // Show loader on page transitions
    const loader = document.createElement('div');
    loader.className = 'loader';
    document.body.appendChild(loader);

    document.querySelectorAll('a').forEach(link => {
        link.addEventListener('click', (e) => {
            if (link.href && !link.href.includes('#') && !link.href.includes('javascript:')) {
                loader.style.display = 'flex';
            }
        });
    });

    // Hide loader on page load
    window.addEventListener('load', () => {
        loader.style.display = 'none';
    });

    // Smooth scroll for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', (e) => {
            e.preventDefault();
            document.querySelector(anchor.getAttribute('href')).scrollIntoView({
                behavior: 'smooth'
            });
        });
    });
});