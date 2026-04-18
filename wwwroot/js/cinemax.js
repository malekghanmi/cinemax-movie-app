// ============================================
//   CINEMAX - 3D Interactions & Animations
// ============================================

document.addEventListener('DOMContentLoaded', () => {

  // ── CUSTOM CURSOR ──
  const cursor = document.querySelector('.cursor');
  const cursorRing = document.querySelector('.cursor-ring');
  if (cursor && cursorRing) {
    let mouseX = 0, mouseY = 0;
    let ringX = 0, ringY = 0;

    document.addEventListener('mousemove', (e) => {
      mouseX = e.clientX; mouseY = e.clientY;
      cursor.style.left = mouseX + 'px';
      cursor.style.top = mouseY + 'px';
    });

    function animateRing() {
      ringX += (mouseX - ringX) * 0.12;
      ringY += (mouseY - ringY) * 0.12;
      cursorRing.style.left = ringX + 'px';
      cursorRing.style.top = ringY + 'px';
      requestAnimationFrame(animateRing);
    }
    animateRing();

    document.querySelectorAll('a, button, .movie-card, .pill, .overlay-btn').forEach(el => {
      el.addEventListener('mouseenter', () => {
        cursor.style.width = '20px';
        cursor.style.height = '20px';
        cursorRing.style.width = '56px';
        cursorRing.style.height = '56px';
      });
      el.addEventListener('mouseleave', () => {
        cursor.style.width = '12px';
        cursor.style.height = '12px';
        cursorRing.style.width = '36px';
        cursorRing.style.height = '36px';
      });
    });
  }

  // ── NAVBAR SCROLL ──
  const navbar = document.querySelector('.navbar');
  if (navbar) {
    window.addEventListener('scroll', () => {
      navbar.classList.toggle('scrolled', window.scrollY > 50);
    });
  }

  // ── 3D CARD TILT ──
  document.querySelectorAll('.movie-card').forEach(card => {
    card.addEventListener('mousemove', (e) => {
      const rect = card.getBoundingClientRect();
      const x = ((e.clientX - rect.left) / rect.width - 0.5) * 2;
      const y = ((e.clientY - rect.top) / rect.height - 0.5) * 2;
      card.style.transform = `
        translateY(-12px)
        rotateY(${x * 8}deg)
        rotateX(${-y * 8}deg)
        scale(1.02)
      `;
    });
    card.addEventListener('mouseleave', () => {
      card.style.transform = '';
    });
  });

  // ── DETAIL POSTER 3D ──
  const detailPoster = document.querySelector('.detail-poster');
  if (detailPoster) {
    detailPoster.addEventListener('mousemove', (e) => {
      const rect = detailPoster.getBoundingClientRect();
      const x = ((e.clientX - rect.left) / rect.width - 0.5) * 2;
      const y = ((e.clientY - rect.top) / rect.height - 0.5) * 2;
      detailPoster.style.transform = `perspective(800px) rotateY(${x * 12}deg) rotateX(${-y * 8}deg)`;
    });
    detailPoster.addEventListener('mouseleave', () => {
      detailPoster.style.transform = 'perspective(800px) rotateY(5deg)';
    });
  }

  // ── SCROLL ANIMATIONS ──
  const observer = new IntersectionObserver((entries) => {
    entries.forEach((entry, i) => {
      if (entry.isIntersecting) {
        setTimeout(() => {
          entry.target.classList.add('visible');
        }, i * 80);
        observer.unobserve(entry.target);
      }
    });
  }, { threshold: 0.1 });

  document.querySelectorAll('.fade-in, .movie-card').forEach(el => {
    if (!el.classList.contains('fade-in')) el.classList.add('fade-in');
    observer.observe(el);
  });

  // ── PARTICLES ──
  const particlesContainer = document.querySelector('.particles');
  if (particlesContainer) {
    for (let i = 0; i < 20; i++) {
      const p = document.createElement('div');
      p.className = 'particle';
      p.style.left = Math.random() * 100 + '%';
      p.style.width = p.style.height = (Math.random() * 3 + 1) + 'px';
      p.style.animationDuration = (Math.random() * 15 + 10) + 's';
      p.style.animationDelay = (Math.random() * 15) + 's';
      p.style.background = Math.random() > 0.5 ? 'var(--accent-red)' : 'var(--accent-cyan)';
      particlesContainer.appendChild(p);
    }
  }

  // ── TOAST AUTO-DISMISS ──
  const toast = document.querySelector('.toast');
  if (toast) {
    setTimeout(() => {
      toast.style.animation = 'toastIn 0.4s reverse forwards';
      setTimeout(() => toast.remove(), 400);
    }, 4000);
  }

  // ── POSTER PREVIEW ──
  const posterUrlInput = document.getElementById('PosterUrl');
  const posterFileInput = document.getElementById('posterFile');
  const posterPreview = document.querySelector('.poster-preview');
  
  function updatePreview(src) {
    if (posterPreview && src) {
      posterPreview.src = src;
      posterPreview.style.display = 'block';
    }
  }

  if (posterUrlInput) {
    posterUrlInput.addEventListener('input', () => updatePreview(posterUrlInput.value));
    if (posterUrlInput.value) updatePreview(posterUrlInput.value);
  }

  if (posterFileInput) {
    posterFileInput.addEventListener('change', (e) => {
      const file = e.target.files[0];
      if (file) {
        const reader = new FileReader();
        reader.onload = (ev) => updatePreview(ev.target.result);
        reader.readAsDataURL(file);
      }
    });
  }

  // ── SEARCH LIVE COUNT ──
  const searchInput = document.querySelector('input[name="searchString"]');
  const movieCount = document.getElementById('movieCount');
  if (searchInput && movieCount) {
    const total = parseInt(movieCount.dataset.total || '0');
    searchInput.addEventListener('input', () => {
      const q = searchInput.value.toLowerCase();
      const cards = document.querySelectorAll('.movie-card');
      let visible = 0;
      cards.forEach(card => {
        const title = card.querySelector('.card-title')?.textContent.toLowerCase() || '';
        if (!q || title.includes(q)) {
          card.style.display = '';
          visible++;
        } else {
          card.style.display = 'none';
        }
      });
    });
  }

  // ── COUNTER ANIMATION ──
  document.querySelectorAll('.stat-number[data-target]').forEach(el => {
    const target = parseInt(el.dataset.target);
    let current = 0;
    const step = target / 60;
    const timer = setInterval(() => {
      current = Math.min(current + step, target);
      el.textContent = Math.round(current) + (el.dataset.suffix || '');
      if (current >= target) clearInterval(timer);
    }, 20);
  });

});
