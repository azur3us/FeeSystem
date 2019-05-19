document.getElementsByName("Bank").forEach(bank => bank.addEventListener('input', () => document.querySelector(".btn-transfer").href = bank.dataset.href));

