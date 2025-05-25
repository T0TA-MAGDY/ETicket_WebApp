const style = document.createElement('style');
style.textContent = `
            .hover-zoom {
                transition: transform 0.3s ease;
            }
            .hover-zoom:hover {
                transform: scale(1.1);
            }
           
            .zoom-img {
                transition: transform 0.4s ease;
                display: block;
                margin: 0 auto;
            }
            .zoom-img:hover {
                transform: scale(1.4);
            }

            .move-btn {
                display: inline-block;
                transition: transform 0.3s ease;
                margin: 0 10px;
            }
            .move-btn:hover {
                transform: translateY(-5px);
            }
        `;
document.head.appendChild(style);