# Changelog

Dieser Changelog dokumentiert alle wesentlichen Änderungen an diesem Branch (`exp-pwa-standalone`) bis zum Commit c085cfb.

Aufgrund von Vorbereitungen zur Veröffentlichung und Optimierungen für eine öffentlichen Testinstanz wird dieser Changelog erst ab
Abschluss der Arbeiten wieder aktualisiert.

Mithilfe von KI aus Git-Logs generiert.

---

All notable changes to this branch (`exp-pwa-standalone`) until c085cfb are documented in this file.

## Unreleased (exp-pwa-standalone)

### Changed
- Update logo, enhance About & IP pages, clean up code.  
  - Replaced `logo.png` (branding update).  
  - Enhanced `About.razor`: added logo, improved layout, designer/developer info + GitHub link; added corresponding CSS/SCSS.  
  - Improved `IP.razor` visualization: clearer distinction of netbits/subnetbits/hostbits, added binary representations and explanatory color coding; updated CSS/SCSS (subnetbits styling).  
  - Simplified `Debug.razor` log output; cleaned up `Home.razor` (removed unused code).  
  - Bumped `BSNTools.Web.csproj` version to `0.0.0.109`; removed `wwwroot\js\` folder entry.  
  - Replaced `HILFE.md` content with a placeholder message.  
  (c085cfb, 2026-02-20, zxrohex)

### Added
- Standalone branch created + initial work and improvements.  
  (6816cc3, 2026-02-20, zxrohex)
- Binary IP “Infos” dialog and supporting `IPAddressExtensions`.  
  (916bdb3, 2026-02-06, zxrohex)
- Input components:
  - `InputBox` (prompt()-like text input with OK/Cancel)
  - `CustomDialog` (RenderFragment-based dialog for custom content)  
  (29dbc8f, 2026-02-03, zxrohex; co-authored-by Claude Opus 4.5)
- Web-API and server project for storage/retrieval of document views (and additional work).  
  (5c8a9cd, 2026-02-03, zxrohex)
- Experimental branch foundation with major Windows 1.x/2.x style redesign, layout improvements, and various fixes (e.g. unit converter).  
  (b725c11, 2026-02-03, zxrohex)
- Initial repository/project scaffolding:
  - Project files
  - `.gitattributes`, `.gitignore`, `README.md`  
  (3b33048 / afc2461, 2026-01-27, zxrohex)

### Fixed
- Subnet calculation and display fixes.  
  (0cd7c6d, 2026-02-03, zxrohex)

### Notes / Misc
- Various iterative work-in-progress commits (“Weitere Arbeiten”, styling/sizing iterations).  
  (5e731d9, 0969fc5, cdac96f, 9127dae, 8799724, 3da6b07; 2026-01-27 → 2026-02-03, zxrohex)

---

## Commit list (chronological)

- 2026-01-27 afc2461 Add .gitattributes, .gitignore, and README.md.
- 2026-01-27 3b33048 Add project files.
- 2026-01-27 5e731d9 Weitere Arbeiten an Design und Funktionalität
- 2026-01-27 0969fc5 Config-Store, Settings-Funktionen hinzugefügt, Test-Stage-Version der IP-Infos-Output hinzugefügt, Checkbox-Verbesserungen, Arbeiten an Window-Sizes, und andere Änderungen
- 2026-01-27 cdac96f Weitere Arbeiten; Styling hinzugefuegt aber etwas kaputt
- 2026-01-27 9127dae Window-Sizing gefixt, weitere Arbeiten
- 2026-01-28 8799724 Weitere Arbeiten
- 2026-02-03 3da6b07 Weitere Arbeiten
- 2026-02-03 0cd7c6d Subnets-Berechnung und Anzeige gefixt
- 2026-02-03 b725c11 Initial experimental branch commit; Design grundlegend geändert im Windows 1.x/2.x-Style, Layout-Verbesserungen. weitere Verbesserungen und Fixes (Einheitenumrechner, etc)
- 2026-02-03 29dbc8f Add InputBox and CustomDialog components
- 2026-02-03 5c8a9cd Web-API und Server-Projekt fuer Storage und Abruf von Dokumentenansichten, und weiteres, hinzugefuegt
- 2026-02-03 c03c510 Verschiedene Änderungen
- 2026-02-06 916bdb3 Refactor IP-Tools UI, add binary info dialog
- 2026-02-20 6816cc3 Standalone-Branch initial commit, weitere Arbeiten und Verbesserungen
- 2026-02-20 c085cfb Update logo, enhance About & IP pages, clean up code